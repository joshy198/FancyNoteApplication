using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.NotesApp.Model
{
    public class DeleteMessage : GenericMessage<Note>
    {
        public DeleteMessage(Note content)
            : base(content)
        {
        }

        public DeleteMessage(object sender, Note content)
            : base(sender, content)
        {
        }

        public DeleteMessage(object sender, object target, Note content)
            : base(sender, target, content)
        {
        }
    }
}
