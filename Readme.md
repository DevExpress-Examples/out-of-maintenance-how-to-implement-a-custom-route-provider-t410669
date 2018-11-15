<!-- default file list -->
*Files to look at*:

* [Form1.cs](./CS/CustomRouteProvider/Form1.cs) (VB: [Form1.vb](./VB/CustomRouteProvider/Form1.vb))
<!-- default file list end -->
# How To: Implement a Custom Route Provider


This example demonstrates how create a custom route provider and use it to calculate a route between two geographical points.


<h3>Description</h3>

To do this, design a class inheriting the&nbsp; <a href="https://documentation.devexpress.com/#WindowsForms/clsDevExpressXtraMapInformationDataProviderBasetopic">InformationDataProviderBase</a>&nbsp;abstract class and implement its CreateData() method. Then, design a class inheriting the&nbsp;<a href="https://documentation.devexpress.com/#WindowsForms/clsDevExpressXtraMapIInformationDatatopic">IInformationData</a>&nbsp;interface and&nbsp;override&nbsp;its&nbsp;<a href="https://documentation.devexpress.com/#WindowsForms/DevExpressXtraMapIInformationData_OnDataResponsetopic">OnDataResponse</a>&nbsp;event. Implement the CalculateRouteCore method to provide custom route calculations.

<br/>


