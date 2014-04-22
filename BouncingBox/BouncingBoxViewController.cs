using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Threading;

namespace BouncingBox
{
    public partial class BouncingBoxViewController : UIViewController
    {
	

        public BouncingBoxViewController() : base("BouncingBoxViewController", null)
        {
        }

        public override void DidReceiveMemoryWarning()
        {
            // Releases the view if it doesn't have a superview.
            base.DidReceiveMemoryWarning();
			
            // Release any cached data, images, etc that aren't in use.
        }

		UIDynamicAnimator animator;

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
			this.View.BackgroundColor = UIColor.White;

			//Create Square
			var redSquare = new UIView(new RectangleF(new PointF(100f, 0f), new SizeF(150f, 150f))){BackgroundColor = UIColor.Red};
			View.Add(redSquare);

			//Setup UIDynamics
		    animator = new UIDynamicAnimator(View);
			UIGravityBehavior gravityBehavior = new UIGravityBehavior(redSquare);
			animator.AddBehavior(gravityBehavior);

			UICollisionBehavior collisionBehavior = new UICollisionBehavior(redSquare) { TranslatesReferenceBoundsIntoBoundary = true };
			animator.AddBehavior(collisionBehavior);

			UIDynamicItemBehavior elasticityBehavior = new UIDynamicItemBehavior(redSquare) { Elasticity = 0.7f };
			animator.AddBehavior(elasticityBehavior);
        }

    }
}

