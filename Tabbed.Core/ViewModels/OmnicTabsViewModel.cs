using System.Windows.Input;
using Cirrious.MvvmCross.ViewModels;
using System.Collections.Generic;
using OmnicTabs.Core.Services;
using System.Threading.Tasks;

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
        
        public ICommand ZoomImageCommand
        {
            // I thinks its a bug, but ShowViewModel<T> doesnt work, so for now i pass params throu static.
            get { Parameters.ImageUrl ="http://lorempixel.com/200/200"; return new MvxCommand(() => ShowViewModel(typeof(GrandChildViewModel))); }
        }
        public ICommand RefreshCommand
        {
            get { return new MvxCommand(() => LoadImages(new ImageLoader())); }
        }

        public string Refresh { get { return "Refresh"; } }

        List<Image> _images;
        public List<Image> Images
        {
            get { return _images; }
            set { _images = value; RaisePropertyChanged(() => Images); }
        }

        public Child1ViewModel(IImageService service)
        {
            LoadImages(service);
        } 
        private async void LoadImages(IImageService service)
        {
             Images = await Task<List<Image>>.Factory.StartNew(() =>
                {
                    var newList = new List<Image>();
                    for (var i = 0; i < 1000; i++)
                    {
                        var newKitten = service.ImageFactory();
                        newList.Add(newKitten);
                    }

                    return newList;
                });
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
       public string ImageUrl
        {
            get { return Parameters.ImageUrl; }
            set { Parameters.ImageUrl = value; RaisePropertyChanged(() => ImageUrl); }
        }
    }
    public static class Parameters
    {
        public static string ImageUrl { get; set; }
    }
}
