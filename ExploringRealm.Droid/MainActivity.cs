using System;
using Android.App;
using Android.OS;
using Android.Widget;
using ExploringRealm.Core.Model;
using ExploringRealm.Core.Service;

namespace ExploringRealm.Droid
{
    [Activity(Label = "ExploringRealm", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        int count = 1;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

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
    }
}