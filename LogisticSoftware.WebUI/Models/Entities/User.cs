using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogisticSoftware.WebUI.Models.Entities
{
    [Table("Users")]
    public class User
    {
        public int UserId { get; set; }

        [Required]
        [DisplayName("����")]
        public string Login { get; set; }

        [Required]

        public string PasswordMd5 { get; set; }

        [Required]
        [DisplayName("��'�")]
        public string FirstName { get; set; }

        [Required]
        [DisplayName("��-�������")]
        public string MiddleName { get; set; }

        [Required]
        [DisplayName("�������")]
        public string LastName { get; set; }

        [Required]
        [DisplayName("�������� �������")]
        public string MobilePhone { get; set; }

        [Required]
        [DisplayName("���� ����������")]
        public DateTime DateOfBirth { get; set; }

        public override string ToString()
        {
            return Login + ", "
                + MobilePhone + ", "
                + DateOfBirth.ToString("dd.MM.yyyy");
        }
    }
}
