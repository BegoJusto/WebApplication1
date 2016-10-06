<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="EjemploWebForm.index" %>

<!DOCTYPE html>
<html lang="es-es">
<head runat="server">
    <meta charset="utf-8" />
    <title></title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" integrity="sha384-BVYiiSIFeK1dGmJRAkycuHAHRg32OmUcww7on3RYdg4Va+PmSTsz/K68vbdEjh4u" crossorigin="anonymous">

    <!-- Optional theme -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap-theme.min.css" integrity="sha384-rHyoN1iRsVXV4nD0JutlnGaslCJuC7uwjduW9SVrLvRYooPp2bWYgmgJQIXwl/Sp" crossorigin="anonymous">
    <script src="http://code.jquery.com/jquery-2.2.4.min.js" integrity="sha256-BbhdlvQf/xTY9gja0Dq3HiwQF8LaCRTXxZKRutelT44=" crossorigin="anonymous"></script>
    <!-- Latest compiled and minified JavaScript -->
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js" integrity="sha384-Tc5IQib027qvyjSMfHjOMaLkfuWVxZxUPnCJA7l2mCWNIpG9mGCD8wGNIcPD7Txa" crossorigin="anonymous"></script>

</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager runat="server" ID="ScriptManager" />

        <div>
            <asp:Menu ID="Menu1" runat="server">
                <Items>
                    <asp:MenuItem NavigateUrl="~/index.aspx" Text="Pagina principal" Value="Pagina principal"></asp:MenuItem>
                </Items>
            </asp:Menu>
            <asp:UpdatePanel runat="server" ID="upPanelUsuario">
                <ContentTemplate>
                    
                    <asp:GridView DataKeyNames="codUsuario" OnRowCommand="grdv_Usuarios_RowCommand" ID="grdv_Usuarios" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False">
                        <Columns>                           
                            <asp:BoundField DataField="codUsuario" Visible="False" />
                            <asp:BoundField DataField="nombre" HeaderText="Nombre" Visible="true" />
                            <asp:BoundField DataField="apellidos" HeaderText="Apellidos" Visible="true" />
                            <asp:BoundField DataField="mail" HeaderText="Mail" Visible="true" />
                            <asp:BoundField DataField="fNacimiento" HeaderText="Fec Nac" Visible="true" />
                            <asp:BoundField DataField="password" HeaderText="Password" Visible="true" />
                            <asp:BoundField DataField="userid" HeaderText="Userid" Visible="true" />
                            <asp:BoundField DataField="borrado" HeaderText="Borrado" Visible="false" />
                            
                             <asp:ButtonField CommandName="editUsuario" Text="Editar" ControlStyle-CssClass="btn btn-info">
                                <ControlStyle CssClass="btn btn-info" />
                            </asp:ButtonField>
                            <asp:ButtonField CommandName="deleteUsuario" Text="Borrar" ControlStyle-CssClass="btn btn-danger">
                                <ControlStyle CssClass="btn btn-danger" />
                            </asp:ButtonField>
                        </Columns>
                    </asp:GridView>
                    <asp:Button ID="btncrearUsuario" runat="server" Text="Crear Usuario" OnClick="btncrearUsuario_Click" />
                </ContentTemplate>
            </asp:UpdatePanel>

            <div class="modal fade row" id="editModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel">
                <div class="modal-dialog" role="document">
                    <div class="modal-content col-md-12 col-xs-12">
                        <div class="modal-header col-md-8 col-xs-6" >
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                            <h4 class="modal-title" id="exampleModalLabel">Formulario</h4>
                        </div>
                        <div class="modal-body col-md-6 col-xs-6" >
                            <asp:Label runat="server" ID="lblIdUsuario" Visible="false" Text=""></asp:Label>

                            <asp:Label runat="server" ID="lblNombreUsuario" Visible="true" Text="Nombre de Usuario" ></asp:Label>
                            <asp:TextBox ID="txtNombreUsuario" runat="server" Text=""></asp:TextBox>
                           
                            <asp:Label runat="server" ID="lblapellidos" Visible="true" Text="Apellidos" ></asp:Label>
                            <asp:TextBox ID="txtApellidos" runat="server" Text=""></asp:TextBox>
                           
                            <asp:Label runat="server" ID="lblmail" Visible="true" Text="Mail" ></asp:Label>
                            <asp:TextBox ID="txtMail" runat="server" Text=""></asp:TextBox>

                            <asp:Label runat="server" ID="lblFNacimiento" Visible="true" Text="FNacimiento" ></asp:Label>
                            <asp:TextBox ID="txtFNacimiento" runat="server" Text=""></asp:TextBox>

                            <asp:Label runat="server" ID="lblpassword" Visible="true" Text="Password" ></asp:Label>
                            <asp:TextBox ID="txtpassword" runat="server" Text=""></asp:TextBox>

                            <asp:Label runat="server" ID="lbluserid" Visible="true" Text="UserId" ></asp:Label>
                            <asp:TextBox ID="txtuserid" runat="server" Text=""></asp:TextBox>

                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                            <asp:Button runat="server" class="btn btn-primary" OnClick="btnGuardarUsuario_Click" ID="btnGuardarUsuario" Text="Guardar" />
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

                            <asp:TextBox ID="txtIdUsuario" runat="server" Enabled="false" Visible="false"></asp:TextBox>


                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-default" data-dismiss="modal">Cancelar</button>
                            <asp:Button ID="btnDelete" runat="server" OnClick="btnDelete_Click" Text="Borrar" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
