using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.NotesApp.Model
{
    public class EditMessage : GenericMessage<Note>
    {
        public EditMessage(Note content)
            : base(content)
        {
        }

        public EditMessage(object sender, Note content)
            : base(sender, content)
        {
        }

        public EditMessage(object sender, object target, Note content)
            : base(sender, target, content)
        {
        }
    }
}
