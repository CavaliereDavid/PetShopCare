// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");
using PetShopCare.Library;
using PetShopCare.Library.Test;

var context = ContextBuilder.GetContext();

await UserManagerTest.TestGetUserById(context);

