<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="autor.aspx.cs" Inherits="EjemploWebForm.autor" %>

<!DOCTYPE html>
<html lang="es-es">
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta charset="utf-8" />
    <title>Gestión de Librería</title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" integrity="sha384-BVYiiSIFeK1dGmJRAkycuHAHRg32OmUcww7on3RYdg4Va+PmSTsz/K68vbdEjh4u" crossorigin="anonymous">

    <!-- Optional theme -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap-theme.min.css" integrity="sha384-rHyoN1iRsVXV4nD0JutlnGaslCJuC7uwjduW9SVrLvRYooPp2bWYgmgJQIXwl/Sp" crossorigin="anonymous">
    <script src="http://code.jquery.com/jquery-2.2.4.min.js" integrity="sha256-BbhdlvQf/xTY9gja0Dq3HiwQF8LaCRTXxZKRutelT44=" crossorigin="anonymous"></script>
    <!-- Latest compiled and minified JavaScript -->
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js" integrity="sha384-Tc5IQib027qvyjSMfHjOMaLkfuWVxZxUPnCJA7l2mCWNIpG9mGCD8wGNIcPD7Txa" crossorigin="anonymous"></script>

</head>
<body>
    <div class="container">
        <div class="row">
            <div class="col-md-12 col-lg-12 col-sm-12 col-xs-12">

                <form id="form1" runat="server" class="form-horizontal">
                    <asp:ScriptManager runat="server" ID="ScriptManager" />

                    <div class="row center-block">
                        <div class="col-md-3">
                            <asp:Menu ID="Menu1" runat="server">
                                <Items>
                                    <asp:MenuItem NavigateUrl="~/index.aspx" Text="Pagina principal" Value="Pagina principal"></asp:MenuItem>
                                    <asp:MenuItem NavigateUrl="~/autor.aspx" Text="Autores" Value="Autores"></asp:MenuItem>
                                </Items>
                            </asp:Menu>
                        </div>
                    </div>
                    <h3 style="color:blue">Autores</h3>
                    <div class="row center-block">
                        <div class="col-md-12 col-lg-12 col-sm-12 col-xs-12">
                            <asp:UpdatePanel runat="server" ID="upPanelAutor">
                                <ContentTemplate>
                                    <asp:GridView DataKeyNames="codAutor" OnRowCommand="grdv_Autor_RowCommand" ID="grdv_Autor" runat="server" AllowPaging="True" 
                                        AllowSorting="True" AutoGenerateColumns="False" BorderColor="Beige" HeaderStyle-Font-Size="Medium" HeaderStyle-VerticalAlign="Middle" 
                                        HeaderStyle-HorizontalAlign="Center">
                                        <Columns>
                                            <asp:BoundField DataField="codAutor" Visible="False" />
                                            <asp:BoundField DataField="nombre" HeaderText="Nombre" Visible="true"  ItemStyle-Width="150px" />

                                            <asp:ButtonField CommandName="editAutor" Text="Editar" ControlStyle-CssClass="btn btn-info">
                                                <ControlStyle CssClass="btn btn-info"   Width="75px"/>
                                            </asp:ButtonField>
                                            <asp:ButtonField CommandName="deleteAutor" Text="Borrar" ControlStyle-CssClass="btn btn-danger">
                                                <ControlStyle CssClass="btn btn-danger"   Width="75px"/>
                                            </asp:ButtonField>
                                        </Columns>
                                    </asp:GridView>
                                    <asp:Button ID="btncrearAutor" runat="server" Text="Crear Autor" OnClick="btncrearAutor_Click"   Width="150px" />
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                    <div class="modal fade row" id="editModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel">
                        <div class="modal-dialog" role="document">
                            <div class="modal-content col-md-12 col-xs-12">
                                <div class="modal-header col-md-12 col-xs-12">
                                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                    <h3 class="modal-title" id="exampleModalLabel">Formulario</h3>
                                </div>
                                <div class="modal-body col-md-12 col-xs-12">
                                    <asp:Label runat="server" ID="lblIdAutor" Visible="false" Text=""></asp:Label>

                                    <div class="form-group">
                                        <div class="col-md-8">
                                            <asp:Label runat="server" ID="lblNombreAutor" Visible="true" Text="Nombre de Autor"></asp:Label>
                                            <asp:TextBox ID="txtNombreAutor" runat="server" Text=""></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="modal-footer">
                                    <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                                    <asp:Button runat="server" class="btn btn-primary" OnClick="btnGuardarAutor_Click" ID="btnGuardarAutor" Text="Guardar" />
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="modal fade" id="deleteConfirm" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel">
                        <div class="modal-dialog" role="document">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                    <h4 class="modal-title" id=""></h4>
                                </div>
                                <div class="modal-body">
                                    <asp:Label ID="lblMensaje" runat="server" Text="¿Esta usted seguro que desea borrar?"></asp:Label>

                                    <asp:TextBox ID="txtIdAutor" runat="server" Enabled="false" Visible="false"></asp:TextBox>


                                </div>
                                <div class="modal-footer">
                                    <button type="button" class="btn btn-default" data-dismiss="modal">Cancelar</button>
                                    <asp:Button ID="btnDelete" runat="server" OnClick="btnDelete_Click" Text="Borrar" />
                                </div>
                            </div>
                        </div>
                    </div>

                </form>
            </div>
        </div>
    </div>
</body>
</html>
