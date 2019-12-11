using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MvvmCross.Droid.Support.V7.RecyclerView.ItemTemplates;

namespace CourseApp.Droid.Views
{
    public class CategoryTemplateSelector : IMvxTemplateSelector
    {
        public int ItemTemplateId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public int GetItemLayoutId(int fromViewType)
        {
            throw new NotImplementedException();
        }

        public int GetItemViewType(object forItemObject)
        {
            throw new NotImplementedException();
        }
    }
}