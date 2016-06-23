using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.NotesApp.Model
{
    public class EditMessage : GenericMessage<MyNote>
    {
        public EditMessage(MyNote content)
            : base(content)
        {
        }

        public EditMessage(object sender, MyNote content)
            : base(sender, content)
        {
        }

        public EditMessage(object sender, object target, MyNote content)
            : base(sender, target, content)
        {
        }
    }
}
