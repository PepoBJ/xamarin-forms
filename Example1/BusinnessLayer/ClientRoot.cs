using Csla;
using System;
using System.ComponentModel.DataAnnotations;

namespace BusinnessLayer
{
    [Serializable]
    public class ClientRoot : BusinessBase<ClientRoot>
    {
        public static readonly PropertyInfo<string> NameProperty = RegisterProperty<string>(c => c.Name);

        [Required]
        public string Name
        {
            get { return GetProperty(NameProperty); }
            set { SetProperty(NameProperty, value); }
        }

        public static readonly PropertyInfo<string> EmailProperty = RegisterProperty<string>(c => c.Email);

        [StringLength(15)]
        public string Email
        {
            get { return GetProperty(EmailProperty); }
            set { SetProperty(EmailProperty, value); }
        }

        public static ClientRoot NewEditableClientRoot()
        {
            return DataPortal.Create<ClientRoot>();
        }
    }
}
