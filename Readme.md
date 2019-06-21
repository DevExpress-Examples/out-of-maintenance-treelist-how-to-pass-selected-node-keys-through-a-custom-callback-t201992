<!-- default file list -->
*Files to look at*:

* [HomeController.cs](./CS/TreeListEditing/Controllers/HomeController.cs) (VB: [HomeController.vb](./VB/TreeListEditing/Controllers/HomeController.vb))
* [Data.cs](./CS/TreeListEditing/Models/Data.cs) (VB: [Data.vb](./VB/TreeListEditing/Models/Data.vb))
* **[Index.cshtml](./CS/TreeListEditing/Views/Home/Index.cshtml)**
* [TreeListPartial.cshtml](./CS/TreeListEditing/Views/Home/TreeListPartial.cshtml)
<!-- default file list end -->
# TreeList - How to pass selected node keys through a custom callback
<!-- run online -->
**[[Run Online]](https://codecentral.devexpress.com/t201992)**
<!-- run online end -->


This example illustrates how to pass data through a custom MVC TreeList callback.<br /><br />- Perform a custom TreeList callback via the client-side <strong>MVCxClientTreeList.PerformCallback</strong> method;<br />- Pass the required data as a parameter;<br />- Handle the <strong>TreeListSettings.CustomActionRouteValues.Action</strong> method and retrieve the passed parameter. In general, it is possible to use the Action method specified for all TreeList callbacks (<strong>TreeListSettings.CallbackRouteValues.Action</strong>). The illustrated technique allows handling a custom TreeList callback within a separate Action method, whose signature can be different. Usually, custom callbacks are used for changing the TreeList's state programmatically in a custom manner;<br />- Pass the retrieved value to the TreeList's PartialView via the ViewData key.<br /><br /><strong>See Also:</strong><br /><a href="https://www.devexpress.com/Support/Center/p/E20065">How to get all GridView selected keys and pass them to a Controller</a>

<br/>


