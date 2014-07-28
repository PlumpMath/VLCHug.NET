using System;
using VLCInterface.Enumerations;

namespace VLCInterface.Core.Events
{
    internal class VLCMediaListEvents
    {
        public delegate void OnItemAdded(IntPtr Item, Int32 Index);
        public delegate void OnWillAddItem(IntPtr Item, Int32 Index);
        public delegate void OnItemDeleted();
        public delegate void OnWillDeleteItem(IntPtr Item, Int32 Index);
        public delegate void OnViewItemAdded();
        public delegate void OnViewWillAddItem();
        public delegate void OnViewItemDeleted();
        public delegate void OnViewWillDeleteItem();
        public delegate void OnPlayerPlayed();
        public delegate void OnPlayerNextItemSet(IntPtr Item);
        public delegate void OnPlayerStopped();
    }
}
