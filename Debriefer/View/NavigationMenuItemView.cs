using System;

namespace Debriefer.View
{
    public class NavigationMenuItemView
    {
        public string Title { get; set; }
        public Action GoTo { get; set; }
    }
}