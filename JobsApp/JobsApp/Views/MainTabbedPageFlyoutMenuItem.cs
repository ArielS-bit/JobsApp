using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobsApp.Views
{
    public class MainTabbedPageFlyoutMenuItem
    {
        public MainTabbedPageFlyoutMenuItem()
        {
            TargetType = typeof(MainTabbedPageFlyoutMenuItem);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}