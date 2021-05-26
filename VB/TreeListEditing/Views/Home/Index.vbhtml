@ModelType System.Collections.IEnumerable
<script type="text/ecmascript">
    var selectedIDs;
    function OnSelectionChanged(s, e) {
        var selectedIDsArray = s.GetVisibleSelectedNodeKeys();
        selectedIDs = selectedIDsArray.join(',');
    }
    function OnEndCallback(s, e) {
        if (s.cpValuesFromController) {
            alert("Values From: Client -> Custom Callback -> Controller -> PartialView: " + s.cpValuesFromController);
            delete s.cpValuesFromController;
        }
    }
    function OnClick(s, e) {
        treeListEmployees.PerformCallback({ selectedNodesIDs: selectedIDs });
    }
</script>
@Html.Partial("TreeListPartial", Model)
@Html.DevExpress().Button(
                Sub(settings)
                    settings.Name = "btnCustomCallback"
                    settings.Text = "Pass All Selected Keys Through Custom Callback"
                    settings.ClientSideEvents.Click = "OnClick"
                End Sub).GetHtml()