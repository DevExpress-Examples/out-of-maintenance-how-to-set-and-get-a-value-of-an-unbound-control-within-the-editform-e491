<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128542434/13.1.4%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E491)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [Default.aspx](./CS/SetEditTemplateValueInCode/Default.aspx) (VB: [Default.aspx](./VB/SetEditTemplateValueInCode/Default.aspx))
* [Default.aspx.cs](./CS/SetEditTemplateValueInCode/Default.aspx.cs) (VB: [Default.aspx.vb](./VB/SetEditTemplateValueInCode/Default.aspx.vb))
<!-- default file list end -->
# How to set and get a value of an unbound control within the EditForm
<!-- run online -->
**[[Run Online]](https://codecentral.devexpress.com/e491/)**
<!-- run online end -->


<p>If you use an unbound control within the EditForm template, you may need to set its value when editing starts, and read it back when editing is done. The HtmlEditFormCreated event must be used to initialize template controls. To read new values, use the RowUpdating and RowInserting events, which are called when editing is done.</p>

<br/>


