<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Graph.ascx.cs" Inherits="RLM.Construction.WebApplication.UserControl.Graph" %>
<canvas id="graphCanvas" runat='server'></canvas>
<script type="text/javascript">
    $(document).ready(function() {
        <asp:literal id='ltrScript' runat='server' />
    });
</script>