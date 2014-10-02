using System.Windows.Input;
using Cirrious.MvvmCross.ViewModels;
using System.Collections.Generic;
using OmnicTabs.Core.Services;

namespace OmnicTabs.Core.ViewModels
{
    public class OmnicTabsViewModel 
		: MvxViewModel
    {
        public OmnicTabsViewModel()
        {
            Child1 = new Child1ViewModel(new ImageLoader());
            Child2 = new Child2ViewModel();
            Child3 = new Child3ViewModel();
        }
        private Child1ViewModel _child1;
        public Child1ViewModel Child1
        {
            get { return _child1; }
            set { _child1 = value; RaisePropertyChanged(() => Child1); }
        }

        private Child2ViewModel _child2;
        public Child2ViewModel Child2
        {
            get { return _child2; }
            set { _child2 = value; RaisePropertyChanged(() => Child2); }
        }

        private Child3ViewModel _child3;
        public Child3ViewModel Child3
        {
            get { return _child3; }
            set { _child3 = value; RaisePropertyChanged(() => Child3); }
        }
    }

    public class Child1ViewModel
    : MvxViewModel
    {
        
        public ICommand GoCommand
        {
            get { return new MvxCommand(() => ShowViewModel<GrandChildViewModel>());}
        }
        List<Image> _images;
        public List<Image> Images
        {
            get { return _images; }
            set { _images = value; RaisePropertyChanged(() => Images); }
        }

        public Child1ViewModel(IImageService service)
        {
            var newList = new List<Image>();
            for (var i = 0; i < 10; i++)
            {
                var newKitten = service.ImageFactory();
                newList.Add(newKitten);
            }

            Images = newList;
        }
    }
    public class Child2ViewModel
    : MvxViewModel
    {
        private string _bar= @"Hello bar";
        public string Bar
        {
            get { return _bar; }
            set { _bar = value; RaisePropertyChanged(() => Bar); }
        }
        
    }
    public class Child3ViewModel
    : MvxViewModel
    {
        private string _oink = "42";
        public string Oink
        {
            get { return _oink; }
            set { _oink = value; RaisePropertyChanged(() => Oink); }
        }
        
    }
    public class GrandChildViewModel
        : MvxViewModel
    {
        private string _life = "heidi";
        public string Life
        {
            get { return _life; }
            set { _life = value; RaisePropertyChanged(() => Life); }
        }
    }
}
