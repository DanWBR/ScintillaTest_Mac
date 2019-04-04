using System;

using AppKit;
using Foundation;

namespace ScintillaTest
{
    public partial class ViewController : NSViewController
    {
        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var view = new ScintillaBinder.ScintillaView();
            view.Bounds = new CoreGraphics.CGRect(0, 0, 500, 500);
            view.WantsLayer = true;
            view.Layer.BackgroundColor = NSColor.Red.CGColor;
            this.View = view;

        }


        public override NSObject RepresentedObject
        {
            get
            {
                return base.RepresentedObject;
            }
            set
            {
                base.RepresentedObject = value;
                // Update the view, if already loaded.
            }
        }
    }
}
