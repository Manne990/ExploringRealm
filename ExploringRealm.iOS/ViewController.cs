using System;
using ExploringRealm.Core.Model;
using ExploringRealm.Core.Service;
using UIKit;

namespace ExploringRealm.iOS
{
    public partial class ViewController : UIViewController
    {
        protected ViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // Use the service
            var myService = new MyService();

            // Check the number of items
            System.Diagnostics.Debug.WriteLine($"Number of items: {myService.GetItems().Count}");

            // List items already in the repository
            foreach (var item in myService.GetItems())
            {
                System.Diagnostics.Debug.WriteLine($"{item.Id}, {item.SomeDate}, {item.SomeDecimal}, {item.SomeInt}");
            }

            // Remove all items
            myService.ClearAllItems();

            // Check that it's empty
            System.Diagnostics.Debug.WriteLine($"Number of items: {myService.GetItems().Count}");

            // Create some items
            var firstId = Guid.NewGuid();

            myService.SaveItem(new MyModel { Id = firstId, SomeDate = DateTime.Now, SomeDecimal = 1.12345M, SomeInt = 1 });
            myService.SaveItem(new MyModel { Id = Guid.NewGuid(), SomeDate = DateTime.Now.AddMinutes(-5), SomeDecimal = 2.12345M, SomeInt = 2 });
            myService.SaveItem(new MyModel { Id = Guid.NewGuid(), SomeDate = DateTime.Now.AddMinutes(-5), SomeDecimal = 3.12345M, SomeInt = 3 });

            // List all items
            foreach (var item in myService.GetItems())
            {
                System.Diagnostics.Debug.WriteLine($"{item.Id}, {item.SomeDate}, {item.SomeDecimal}, {item.SomeInt}");
            }

            // Print the first item
            var firstItem = myService.GetItem(firstId);

            System.Diagnostics.Debug.WriteLine($"First Item: {firstItem.Id}, {firstItem.SomeDate}, {firstItem.SomeDecimal}, {firstItem.SomeInt}");
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}