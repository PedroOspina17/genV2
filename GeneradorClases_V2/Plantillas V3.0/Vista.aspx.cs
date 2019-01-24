using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace <Namespace>
{
    public partial class <TableName> : System.Web.UI.Page
    {

        ReglasNegocio.<TableName> rn<TableName> = new ReglasNegocio.<TableName>();
        Objetos.<TableName> o<TableName>;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    Session["InfoGv"] = rn<TableName>.Listar();
                    gv<TableName>.DataSource = Session["InfoGv"];
                    gv<TableName>.DataBind();
                    <PrimaryKeys>
                    object <FieldName> = Request.QueryString["<FieldName>"];
					</PrimaryKeys>
                    if (<PrimaryKeys><FieldName> != null &&
					</PrimaryKeys>)
                    {
                        CargarDatos(<PrimaryKeys>Convert.To<FieldType>(<FieldName>),
						</PrimaryKeys>);
                    }
                }
            }
            catch (Exception ex)
            {
                
                ClientScript.RegisterStartupScript(Page.GetType(), "Error", "alertify.alert(\"Error al cargar la página\",\"" + ex.Message.Replace("'", "") + "\")", true);
            }
        }

        private void CargarDatos(<PrimaryKeys><FieldType> <FieldName>,
		</PrimaryKeys>)
        {
            try
            {
                o<TableName> = rn<TableName>.ConsultarPorPK(<PrimaryKeys><FieldName>,
				</PrimaryKeys>);
				
				<Fields>
                <PrefixControl><FieldName>.<ControlPropValue> = o<TableName>.<FieldName>.ToString();
				</Fields>
                imgEliminar.Visible = true;
                imgCancelar.Visible = true;
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "Error", "alertify.alert(\"Error al cargar los datos \",\"" + ex.Message.Replace("'", "") + "\")", true);

            }
        }

        protected void CargarProducto(object sender, EventArgs e)
        {
            LinkButton lbProducto = (LinkButton)sender;
            Response.Redirect("<TableName>.aspx?<PrimaryKeys><FieldName>=" + lb<TableName>.CommandArgument +"&"
			</PrimaryKeys>);
        }
        protected void gv<TableName>_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gv<TableName>.PageIndex = e.NewPageIndex;
            gv<TableName>.DataSource = Session["InfoGv"];
            gv<TableName>.DataBind();

        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                Session["InfoGv"] = rn<TableName>.ConsultarVarios(Convert.ToString(txtBuscar.Text));
                gv<TableName>.DataSource = Session["InfoGv"];
                gv<TableName>.DataBind();
            }
            catch (Exception ex)
            {
                
                ClientScript.RegisterStartupScript(Page.GetType(), "Error", "alertify.alert(\"Error al consultar la información. -- \",\"" + ex.Message.Replace("'", "") + "\")", true);
            }
           
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Validar())
                {
                    if (<PrimaryKeys>o<TableName>.<FieldName> != <DefaultValue> &
					</PrimaryKeys>)
                    {
                        rn<TableName>.Actualizar(o<TableName>);
                    }
                    else
                    {
                        rn<TableName>.Crear(o<TableName>);
                    }
                    ClientScript.RegisterStartupScript(Page.GetType(), "Guardar", "alertify.notify(\"Se ha guardado la información con exito.\",\"success\",1.8,function(){location.href='<TableName>.aspx'})", true);
                }
                else
                {
                    ClientScript.RegisterStartupScript(Page.GetType(), "Validar", "alertify.notify(\"Por favor verifique la información e intentelo de nuevo.\",\"warning\",13.5)", true);
                }
                
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "Error", "alertify.alert(\"Error al guardar la información. --\",\"" + ex.Message.Replace("'", "") + "\")", true);
            }
        }

        private bool Validar()
        {
            o<TableName> = new Objetos.<TableName>();
            bool Valido = true;
            try
            {
				//ToDo: Eliminar control a las primary key y a los campos not required
				<Fields>
                if(<PrefixControl><FieldName>.<ControlPropValue>.Trim() != "<DefaultValue>")  
                {
                    try 
	                {
                        o<TableName>.<FieldName> = Convert.To<FieldType>(<PrefixControl><FieldName>.<ControlPropValue>);
	                }
	                catch (Exception)
	                {
                        ClientScript.RegisterStartupScript(Page.GetType(), "<FieldName>", "alertify.notify('El valor ingresado en el campo <FieldName> no es válido.','error',13); ", true);
                        Valido = false;
	                }
                }
                else
                {
                    ClientScript.RegisterStartupScript(Page.GetType(), "<FieldName>", "alertify.notify('El campo <FieldName> es obligatorio.','error',13); ", true);
                    Valido = false;
                }
				</Fields>

               
                

            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "Error", "alertify.alert(\"Error al validar los datos \",\"" + ex.Message.Replace("'", "") + "\")", true);
            }
            return Valido;
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "Cancelar", "alertify.confirm(\"Descartar cambios.\",\"¿Está seguro que desea descartar los cambios?.\",function(){ alertify.notify(\"Cambios descartados\",\"custom\",1.4,function(){location.href='<TableName>.aspx';});  }, function(){  alertify.message('Continue haciendo los cambios y presione el boton guardar para conservarlos.');  });", true);
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "Error", "alertify.alert(\"Error al descartar los datos \",\"" + ex.Message.Replace("'", "") + "\")", true);
                
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                rn<TableName>.Retirar(<PrimaryKeys>Convert.To<FieldType>(<PrefixControl><FieldName>.<ControlPropValue>),
		</PrimaryKeys>));
                ClientScript.RegisterStartupScript(Page.GetType(), "Eliminar", "alertify.notify(\"Se ha eliminado la información con exito.\",\"success\",1.8,function(){location.href='<TableName>.aspx'})", true);

            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "Error", "alertify.alert(\"Error al eliminar los datos \",\"" + ex.Message.Replace("'", "") + "\")", true);               
            }
        }
    }
}