﻿using System;
using System.Web.Mvc;
using System.Web.Routing;
using LogisticSoftware.WebUI.Infrastructure.Abstract;
using LogisticSoftware.WebUI.Infrastructure.Concrete;
using Ninject;

namespace LogisticSoftware.WebUI.Infrastructure
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private readonly IKernel _ninjectKernel;
        public NinjectControllerFactory()
        {
            _ninjectKernel = new StandardKernel();
            AddBindings();
        }
        protected override IController GetControllerInstance(RequestContext
        requestContext, Type controllerType)
        {
            return controllerType == null
              ? null
              : (IController)_ninjectKernel.Get(controllerType);
        }
        private void AddBindings()
        {
            _ninjectKernel.Bind<IAuthProvider>().To<FormsAuthProvider>();

        }
    } 

}