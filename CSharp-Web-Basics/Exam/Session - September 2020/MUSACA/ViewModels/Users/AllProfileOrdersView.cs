using System;
using System.Collections.Generic;
using System.Text;

namespace MUSACA.ViewModels.Users
{
    public class AllProfileOrdersView
    {
        public AllProfileOrdersView()
        {
            ProfileOrderViewModel = new List<ProfileOrderViewModel>();
        }

        public List<ProfileOrderViewModel> ProfileOrderViewModel { get; set; }
    }
}
