Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.Linq
Imports System.Web

Namespace TreeListEditing.Models
	Public Class Employee
		Public Sub New()
		End Sub
		Public Sub New(ByVal employeeID As Integer, ByVal supervisorID? As Integer, ByVal firstName As String, ByVal middleName As String, ByVal lastName As String, ByVal title As String)
			Me.EmployeeID = employeeID
			Me.SupervisorID = supervisorID
			Me.FirstName = firstName
			Me.MiddleName = middleName
			Me.LastName = lastName
			Me.Title = title
		End Sub

		<Key>
		Public Property EmployeeID() As Integer

		Public Property SupervisorID() As Integer?

		<Required(ErrorMessage := "First Name is required")>
		Public Property FirstName() As String

		Public Property MiddleName() As String

		<Required(ErrorMessage := "Last Name is required")>
		Public Property LastName() As String

		<Required(ErrorMessage := "Title is required")>
		Public Property Title() As String
	End Class

	Public NotInheritable Class EmployeesDataProvider

		Private Sub New()
		End Sub

		Public Shared Function GetData() As List(Of Employee)
			If HttpContext.Current.Session("Employees") Is Nothing Then
				Dim list As New List(Of Employee)()

				list.Add(New Employee(1, Nothing, "David", "Jordan", "Adler", "Vice President"))
				list.Add(New Employee(2, 1, "Michael", "Christopher", "Alcamo", "Associate Vice President"))
				list.Add(New Employee(3, 1, "Eric", "Zachary", "Berkowitz", "Associate Vice President"))
				list.Add(New Employee(4, 2, "Amy", "Gabrielle", "Altmann", "Business Manager"))
				list.Add(New Employee(5, 3, "Kyle", "", "Bernardo", "Acting Director"))
				list.Add(New Employee(6, 2, "Mark", "Sydney", "Atlas", "Executive Director"))
				list.Add(New Employee(7, 3, "Meredith", "", "Berman", "Manager"))
				list.Add(New Employee(8, 3, "Liz", "", "Bice", "Controller"))

				HttpContext.Current.Session("Employees") = list
			End If
			Return DirectCast(HttpContext.Current.Session("Employees"), List(Of Employee))
		End Function

		Private Shared Function GetEmployeeByID(ByVal employeeID As Integer) As Employee
			Return GetData().Where(Function(e) e.EmployeeID = employeeID).First()
		End Function
		Private Shared Function IsParent(ByVal parentID As Integer, ByVal childID As Integer) As Boolean
			Dim employee As Employee
			Dim employeeID As Integer = childID
			Do While employeeID <> 0
				employee = GetEmployeeByID(employeeID)
				If employee.EmployeeID = parentID Then
					Return True
				End If
				employeeID = CInt(Math.Truncate(If(employee.SupervisorID, 0)))
			Loop
			Return False
		End Function
	End Class
End Namespace