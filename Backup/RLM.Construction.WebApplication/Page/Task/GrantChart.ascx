<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GrantChart.ascx.cs" Inherits="RLM.Construction.WebApplication.Page.Task.GrantChart" %>
<%@ Register Src="~/UserControl/GrantChart.ascx" TagName="GrantChart" TagPrefix="rlm" %>
<div>
    <fieldset>
        <legend id="legend" meta:resourcekey="TaskGrantChartList" runat="server"></legend>
        <div class="ContentWrapper" style="display: table">
                <rlm:GrantChart ID='grantChart' runat="server" />
        </div>
    </fieldset>
</div>