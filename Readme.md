<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128576532/16.1.5%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T410669)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [Form1.cs](./CS/CustomRouteProvider/Form1.cs) (VB: [Form1.vb](./VB/CustomRouteProvider/Form1.vb))
<!-- default file list end -->
# How To: Implement a Custom Route Provider


This example demonstrates how create a custom route provider and use it to calculate a route between two geographical points.


<h3>Description</h3>

To do this, design a class inheriting the&nbsp; <a href="https://documentation.devexpress.com/#WindowsForms/clsDevExpressXtraMapInformationDataProviderBasetopic">InformationDataProviderBase</a>&nbsp;abstract class and implement its CreateData() method. Then, design a class inheriting the&nbsp;<a href="https://documentation.devexpress.com/#WindowsForms/clsDevExpressXtraMapIInformationDatatopic">IInformationData</a>&nbsp;interface and&nbsp;override&nbsp;its&nbsp;<a href="https://documentation.devexpress.com/#WindowsForms/DevExpressXtraMapIInformationData_OnDataResponsetopic">OnDataResponse</a>&nbsp;event. Implement the CalculateRouteCore method to provide custom route calculations.

<br/>


