<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Page.Master" AutoEventWireup="true" CodeBehind="AttachFiles.aspx.cs" Inherits="RLM.Construction.WebApplication.Page.AttachFile.AttachFiles" %>
<%@ Register Src="~/Page/AttachFile/AttachFileList.ascx" TagName="AttachFileList" TagPrefix="rlm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Heading" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
<div class="Padding10 Bold">
    <asp:Literal ID='ltrResourceType' runat="server"></asp:Literal>: 
    <asp:Literal ID='ltrPageTitle' runat="server"></asp:Literal>
</div>
<div>
    <fieldset>
        <legend id='fileUploadTitle' meta:resourcekey="FileUploadTitle" runat="server"></legend>
        <div class="EditFormWrapper">
            <div class="Row">
                <asp:label CssClass="Label" runat="server" meta:resourcekey="SelectFile"></asp:label>
                <input type="file" id='fFile' runat="server" />
            </div>
            <div  class="Row">
                <asp:Button ID='btnUpload' OnClick="btnUpload_OnClick" runat="server" meta:resourcekey="ButtonSave" />
            </div>
        </div>
    </fieldset>
</div>
<rlm:AttachFileList IsShowDeleteButton="true" runat="server" ID='files' />
</asp:Content>
