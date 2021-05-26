@Html.DevExpress().TreeList(
                Sub(settings)
                    settings.Name = "treeListEmployees"
                    settings.CallbackRouteValues = New With {.Controller = "Home", .Action = "TreeListPartial"}
                    settings.CustomActionRouteValues = New With {.Controller = "Home", .Action = "TreeListPartialCustom"}

                    settings.KeyFieldName = "EmployeeID"
                    settings.ParentFieldName = "SupervisorID"

                    settings.SettingsSelection.Enabled = True

                    settings.ClientSideEvents.SelectionChanged = "OnSelectionChanged"
                    settings.ClientSideEvents.EndCallback = "OnEndCallback"

                    settings.CustomJSProperties =
            Sub(s, e)
                If (ViewData("SelectedNodesIDs") IsNot Nothing) Then
                    e.Properties("cpValuesFromController") = ViewData("SelectedNodesIDs").ToString()
                End If
            End Sub
                    settings.Columns.Add("FirstName")
                    settings.Columns.Add("MiddleName")
                    settings.Columns.Add("LastName")
                    settings.Columns.Add("Title")
                End Sub).Bind(Model).GetHtml()