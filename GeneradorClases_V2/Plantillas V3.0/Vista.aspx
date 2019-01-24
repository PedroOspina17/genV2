<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="<TableName>.aspx.cs" Inherits="<Namespace>.<TableName>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            text-align: left;
        }

        .auto-style2 {
            width: 172px;
        }

        .auto-style3 {
            text-align: left;
            width: 172px;
        }
    </style>    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenido" runat="server">
    <table style="margin: 0 auto;" width="95%">
        <tr>
            <td>
                <asp:Label ID="lblTitulo" runat="server" Text="<TableName>" CssClass="Titulo"></asp:Label>

                <br />
                <asp:Label ID="lblLinea" runat="server" Style="color: #FF9900; text-align: center;" Text="_________________________________________"></asp:Label>
                <br />
                <br />
            </td>
        </tr>
        <tr>
            <td>
                <fieldset>
                    <legend>Ingresar: </legend>
                    <table Style=" align:center; width: 90%; margin: 0 auto;">
                        
						<Fields>
                        <tr>
                            <td>&nbsp;</td>
                            <td class="auto-style3">
                                <asp:Label ID="lbl<FieldName>" runat="server" Text="<FieldName>" CssClass="ui-priority-primary"></asp:Label>
                            </td>
                            <td class="auto-style1">							
                                <asp:<ControlByDataType> ID="<PrefixControl><FieldName>" <AtributesControl> runat="server" autocomplete="off" Height="25px"></asp:<ControlByDataType>>
                                <asp:Label ID="lblRequired<FieldName>" runat="server" Text="*" ForeColor="Red"></asp:Label>
                            </td>
                        </tr>
						</Fields>
                        
                        <tr>
                            <td>&nbsp;</td>
                            <td style="text-align: left" class="auto-style2">&nbsp;</td>
                            <td style="text-align: left">&nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                <asp:Button ID="btnGuardar" runat="server" OnClick="btnGuardar_Click" />
                                &nbsp;&nbsp;
                                <asp:Button ID="btnCancelar" runat="server" OnClick="btnCancelar_Click" Visible="False" />
                                &nbsp;&nbsp;
                                <asp:Button ID="btnEliminar" runat="server"  OnClick="btnEliminar_Click" Visible="False" />


                            </td>
                        </tr>

                    </table>
                </fieldset>
            </td>
        </tr>
        <tr>
            <td>
                <br /><br />
                <fieldset>
                    <legend>Consultar: </legend>
                    <table style="width:90%; margin: 0 auto;">
                        <tr>
                            <td>&nbsp;&nbsp;</td></tr>
                        <tr>
                            <td><asp:Label runat="server">Buscar :</asp:Label>
                                <asp:TextBox runat="server" ID="txtBuscar" Height="25px"></asp:TextBox>&nbsp;&nbsp;
                                <asp:Button ID="btnConsultar" runat="server" OnClick="btnConsuktar_Click" formnovalidate  CausesValidation="False" />                                
                        </tr>
                    </table>
                    <br />
                    <asp:GridView ID="gv<TableName>" CssClass="gvListar" HorizontalAlign="Center" runat="server" Style="width: 70%; margin: 0 auto;" AutoGenerateColumns="False" AllowPaging="True" CellPadding="4" ForeColor="#333333" GridLines="None" EmptyDataText="No existen registros." CellSpacing="2" OnPageIndexChanging="gv<TableName>_PageIndexChanging">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
							<PrimaryKeys>						
							<asp:TemplateField HeaderText="<FieldName>" ItemStyle-HorizontalAlign="Left">
								<ItemTemplate>
									<asp:LinkButton ID="lb<FieldName>" CommandArgument='<%# Eval("<FieldName>") %>' Text='<%# Eval("<FieldName>") %>' OnClick="CargarProducto" runat="server"></asp:LinkButton>
								</ItemTemplate>
								<ItemStyle HorizontalAlign="Left"></ItemStyle>
							</asp:TemplateField>
							</PrimaryKeys>
							<Fields>
								<asp:BoundField DataField="<FieldName>" HeaderText="<FieldName>" ItemStyle-HorizontalAlign="Left">
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
								</asp:BoundField>
							</Fields>							                           
                        </Columns>
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EFF3FB" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    </asp:GridView>
                </fieldset>
            </td>
        </tr>
    </table>
    <br /><br />


</asp:Content>
