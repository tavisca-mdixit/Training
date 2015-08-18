About Templar
Templar is a framework for building highly customizable and reusable web applications.
Templar works on the concept of widgets, which are the building blocks for creating sites.
It’s very easy to create widgets at the essence they are ASP.Net user controls which implement an IWidget interface.

This project contains a sample Templar widget called - HtmlWidget

Please note the structure of this project
Widgets
 HTMLWidget
  HtmlWidget.ascx  (Your widget code)
As a best practice you should create a folder for each widget inside the root Widgets folder

Key things to note in this sample
1. We have added a reference to Tavisca.Templar.Contract.dll - this is the dll againse which you create your widgets (located at References\Framework\Tavisca.Templar.Contract.dll)
2. Next we created a user control and implemented IWidget (we are using a 'Class Library' project here for the widget but you can also use a 'ASP.NET Web Application' project if you like)
3. Added a reference of this SampleWidgets project in the main Portal project (this ensures your code dll is deployed properly)
4. Finally we have added a post-build event in this project to copy the widgets folder to root widgets folder

Now the widget is implemented and needs to be added to Templar where you can use it in your site or debug it if required
1. Login to Templar with your new account
2. Go to Admin tab click widgets
3. Click 'Add new widget' link on top
4. Enter details e.g. 
	Widget name: MySampleWidget
	Widget url: HTMLWidget/HtmlWidget.ascx  (This is the very important, it is the relative url for the widget from widgets folder)
	Description, icon, state are options
5. If all went well you should be able to see this widget in preview
6. Now if you create a page than you should be able to see this widget in the top widgets list