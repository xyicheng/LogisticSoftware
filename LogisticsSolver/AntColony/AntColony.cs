using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticsSolver.AntColony
{
    class AntColony
    {

        private readonly Random _random = new Random(0);

        public int Alpha { get; private set; } = 3; // influence of pheromone on direction
        public int Beta { get; private set; } = 2; // influence of adjacent node distance

        public double Rho { get; private set; } = 0.01; // pheromone decrease factor
        public double Q { get; private set; } = 2.0;   // pheromone increase factor

        public int NumCities { get; private set; } = 60;
        public int NumAnts { get; private set; } = 4;
        public int MaxTime { get; private set; } = 1000;
        private int[][] _dists;
        private int[] _bestTrail;
        private int[][] _ants;
        private double[][] _pheromones;


        private void InitAnts()
        {
            _ants = new int[NumAnts][];
            for (var k = 0; k < NumAnts; ++k)
            {
                var start = _random.Next(0, NumCities);
                _ants[k] = RandomTrail(start);
            }
        }

        private int[] RandomTrail(int start) // helper for InitAnts
        {
            var trail = new int[NumCities];

            for (var i = 0; i < NumCities; ++i) { trail[i] = i; } // sequential

            for (var i = 0; i < NumCities; ++i) // Fisher-Yates shuffle
            {
                var r = _random.Next(i, NumCities);
                var tmp = trail[r]; trail[r] = trail[i]; trail[i] = tmp;
            }

            var idx = IndexOfTarget(trail, start); // put start at [0]
            var temp = trail[0];
            trail[0] = trail[idx];
            trail[idx] = temp;

            return trail;
        }

        private int IndexOfTarget(int[] trail, int target) // helper for RandomTrail
        {
            for (var i = 0; i < trail.Length; ++i)
            {
                if (trail[i] == target)
                    return i;
            }
            throw new Exception("Target not found in IndexOfTarget");
        }

        public double Length(int[] trail) // total length of a trail
        {
            var result = 0.0;
            for (var i = 0; i < trail.Length - 1; ++i)
                result += _dists[trail[i]][trail[i + 1]];
            return result;
        }

        private int[] BestTrail() // best trail has shortest total length
        {
            var bestLength = Length(_ants[0]);
            var idxBestLength = 0;
            for (var k = 1; k < _ants.Length; ++k)
            {
                var len = Length(_ants[k]);
                if (len < bestLength)
                {
                    bestLength = len;
                    idxBestLength = k;
                }
            }
            NumCities = _ants[0].Length;
            _bestTrail = new int[NumCities];
            _ants[idxBestLength].CopyTo(_bestTrail, 0);
            return _bestTrail;
        }


        private void InitPheromones()
        {
            _pheromones = new double[NumCities][];
            for (var i = 0; i < NumCities; ++i)
                _pheromones[i] = new double[NumCities];
            foreach (double[] t in _pheromones)
                for (var j = 0; j < t.Length; ++j)
                    t[j] = 0.01; // otherwise first call to UpdateAnts -> BuiuldTrail -> NextNode -> MoveProbs => all 0.0 => throws
        }


        private void UpdateAnts()
        {
            var numCities = _pheromones.Length;
            for (var k = 0; k < _ants.Length; ++k)
            {
                var start = _random.Next(0, numCities);
                var newTrail = BuildTrail(k, start);
                _ants[k] = newTrail;
            }
        }

        private int[] BuildTrail(int k, int start)
        {
            var numCities = _pheromones.Length;
            var trail = new int[numCities];
            var visited = new bool[numCities];
            trail[0] = start;
            visited[start] = true;
            for (var i = 0; i < numCities - 1; ++i)
            {
                var cityX = trail[i];
                var next = NextCity(k, cityX, visited);
                trail[i + 1] = next;
                visited[next] = true;
            }
            return trail;
        }

        private int NextCity(int k, int cityX, bool[] visited)
        {
            // for ant k (with visited[]), at nodeX, what is next node in trail?
            var probs = MoveProbs(k, cityX, visited);

            var cumul = new double[probs.Length + 1];
            for (var i = 0; i < probs.Length; ++i)
                cumul[i + 1] = cumul[i] + probs[i]; // consider setting cumul[cuml.Length-1] to 1.00

            var p = _random.NextDouble();

            for (var i = 0; i < cumul.Length - 1; ++i)
                if (p >= cumul[i] && p < cumul[i + 1])
                    return i;
            throw new Exception("Failure to return valid city in NextCity");
        }

        private double[] MoveProbs(int k, int cityX, bool[] visited)
        {
            // for ant k, located at nodeX, with visited[], return the prob of moving to each city
            var numCities = _pheromones.Length;
            var taueta = new double[numCities]; // inclues cityX and visited cities
            var sum = 0.0; // sum of all tauetas
            for (var i = 0; i < taueta.Length; ++i) // i is the adjacent city
            {
                if (i == cityX)
                    taueta[i] = 0.0; // prob of moving to self is 0
                else if (visited[i])
                    taueta[i] = 0.0; // prob of moving to a visited city is 0
                else
                {
                    taueta[i] = Math.Pow(_pheromones[cityX][i], Alpha) * Math.Pow((1.0 / _dists[cityX][i]), Beta); // could be huge when pheromone[][] is big
                    if (taueta[i] < 0.0001)
                        taueta[i] = 0.0001;
                    else if (taueta[i] > (double.MaxValue / (numCities * 100)))
                        taueta[i] = double.MaxValue / (numCities * 100);
                }
                sum += taueta[i];
            }

            var probs = new double[numCities];
            for (var i = 0; i < probs.Length; ++i)
                probs[i] = taueta[i] / sum; // big trouble if sum = 0.0
            return probs;
        }

        private void UpdatePheromones()
        {
            for (var i = 0; i < _pheromones.Length; ++i)
            {
                for (var j = i + 1; j < _pheromones[i].Length; ++j)
                {
                    foreach (var t in _ants)
                    {
                        var length = Length(t); // length of ant k trail
                        var decrease = (1.0 - Rho) * _pheromones[i][j];
                        var increase = 0.0;
                        if (EdgeInTrail(i, j, t)) increase = (Q / length);

                        _pheromones[i][j] = decrease + increase;

                        if (_pheromones[i][j] < 0.0001)
                            _pheromones[i][j] = 0.0001;
                        else if (_pheromones[i][j] > 100000.0)
                            _pheromones[i][j] = 100000.0;

                        _pheromones[j][i] = _pheromones[i][j];
                    }
                }
            }
        }

        private bool EdgeInTrail(int cityX, int cityY, int[] trail)
        {
            // are cityX and cityY adjacent to each other in trail[]?
            var lastIndex = trail.Length - 1;
            var idx = IndexOfTarget(trail, cityX);

            if (idx == 0 && trail[1] == cityY) return true;
            if (idx == 0 && trail[lastIndex] == cityY) return true;
            if (idx == 0) return false;
            if (idx == lastIndex && trail[lastIndex - 1] == cityY) return true;
            if (idx == lastIndex && trail[0] == cityY) return true;
            if (idx == lastIndex) return false;
            if (trail[idx - 1] == cityY) return true;
            return trail[idx + 1] == cityY;
        }

        public void MakeGraphDistances(int[][] distanses)
        {
            NumCities = distanses.Length;
            _dists = new int[NumCities][];
            for (var i = 0; i < _dists.Length; ++i)
                _dists[i] = new int[NumCities];
            for (var i = 0; i < NumCities; ++i)
                for (var j = i + 1; j < NumCities; ++j)
                {
                    _dists[i][j] = distanses[i][j];
                    _dists[j][i] = distanses[j][i];
                }
            InitAnts(); // initialize ants to random trails
            InitPheromones();
        }

        public int[] GetMinPath()
        {
            _bestTrail = BestTrail(); // determine the best initial trail
            var bestLength = Length(_bestTrail); // the length of the best trail

            var time = 0;
            while (time < MaxTime)
            {
                UpdateAnts();
                UpdatePheromones();

                var currBestTrail = BestTrail();
                var currBestLength = Length(currBestTrail);
                if (currBestLength < bestLength)
                {
                    bestLength = currBestLength;
                    _bestTrail = currBestTrail;
                }
                ++time;
            }
            return _bestTrail;
        }
    }
}
