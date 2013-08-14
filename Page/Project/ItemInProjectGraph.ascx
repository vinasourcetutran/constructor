<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ItemInProjectGraph.ascx.cs" Inherits="RLM.Construction.WebApplication.Page.Project.ItemInProjectGraph" %>
<%@ Register Src="~/UserControl/Graph.ascx" TagName="Graph" TagPrefix="rlm" %>
<div>
    <fieldset>
        <a href='#'><legend id="legend" meta:resourcekey="ItemInProjectPhaseGraph" runat="server"></legend></a>
        <div class="ContentWrapper" style="display: table">
            <ul class='Graph'>
                <li>
                    <rlm:graph ID='graphQuantity' Width=400 Height=400 runat="server" meta:resourceKey="GraphQuantity" />
                </li>
                <li>
                    <rlm:graph ID='graphPrice' Width=400 Height=400 runat="server" meta:resourceKey="GraphPrice" />
                </li>
            </ul>
        </div>
    </fieldset>
</div>
