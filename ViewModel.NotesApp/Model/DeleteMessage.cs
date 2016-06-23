using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.NotesApp.Model
{
    public class DeleteMessage : GenericMessage<MyNote>
    {
        public DeleteMessage(MyNote content)
            : base(content)
        {
        }

        public DeleteMessage(object sender, MyNote content)
            : base(sender, content)
        {
        }

        public DeleteMessage(object sender, object target, MyNote content)
            : base(sender, target, content)
        {
        }
    }
}
