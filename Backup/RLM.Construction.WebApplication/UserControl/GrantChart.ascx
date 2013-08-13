<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GrantChart.ascx.cs" Inherits="RLM.Construction.WebApplication.UserControl.GrantChart" %>
<div class="Row LineHeight10">
<div id='divGrantChart' runat="server" style="position:relative" class="Gantt"></div>
	<script type="text/javascript">
	    $(document).ready(function() {
	        <asp:literal id='ltrGrant' runat='server'/>
	    });
    </script>
</div>