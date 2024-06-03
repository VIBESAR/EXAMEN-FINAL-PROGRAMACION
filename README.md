XmenFinal
XmenFinal es un programa de escritorio desarrollado en C# y .NET Framework que permite gestionar una base de datos de personajes de X-Men utilizando MySQL como sistema de gestión de base de datos. El programa proporciona una interfaz gráfica de usuario (GUI) para realizar operaciones CRUD (Crear, Leer, Actualizar, Eliminar) sobre los registros de personajes.

Formprincipal
La clase `Formprincipal` es una clase que hereda de `Form` y representa la pantalla de inicio del programa XmenFinal. Esta clase contiene los siguientes componentes:
1. **Atributos**
   - `Conexion`: Una instancia de la clase `ConexionXmen` que se encarga de establecer la conexión con la base de datos MySQL.
2. **Constructor**:
   - `Formprincipal()`: El constructor de la clase. Inicializa los componentes de la interfaz de usuario.
3. **Métodos**:
   - `buttonEmpezar_Click(object sender, EventArgs e)`: Este método se ejecuta cuando se hace clic en el botón "Empezar". Crea una nueva instancia de la clase `Forminterfaz`, muestra la ventana correspondiente y oculta la ventana actual (`Formprincipal`).
   - `buttonConexion_Click(object sender, EventArgs e)`: Este método se ejecuta cuando se hace clic en el botón "Conexión". Crea una nueva instancia de la clase `ConexionXmen` y llama al método `ProbarConexion()` de esa clase. Si la conexión es exitosa, muestra un cuadro de diálogo con el mensaje "CONEXION EXITOSA". Si la conexión falla, muestra un cuadro de diálogo con el mensaje "CONEXION FALLIDA".
La clase `Formprincipal` actúa como la pantalla de inicio del programa XmenFinal. Desde esta pantalla, el usuario puede hacer clic en el botón "Empezar" para abrir la interfaz principal (`Forminterfaz`) o puede hacer clic en el botón "Conexión" para verificar la conexión con la base de datos MySQL.

Forminterfaz
La clase `Forminterfaz` es una clase que hereda de `Form` y representa la interfaz principal del programa XmenFinal. Esta clase contiene los siguientes componentes:

1. **Atributos**:
   - `usr`: Una instancia de la clase `usuario` que se utiliza para almacenar y manipular los datos de un personaje.
   - `conect`: Una instancia de la clase `ConexionXmen` que se encarga de la comunicación con la base de datos MySQL.
   - `todos`: Una lista de tipo `usuario` que almacena todos los personajes obtenidos de la base de datos.
   - `cursor1`: Una instancia de la clase `cursor` (no se muestra en el código proporcionado) que se utiliza para llevar un control de la posición actual del registro seleccionado al navegar entre ellos.
   - `nivelesMutacion`: Un arreglo de cadenas que contiene los niveles de mutación disponibles.
   - `grupos`: Un arreglo de cadenas que contiene los grupos o equipos disponibles.
2. **Constructor**:
   - `Forminterfaz()`: El constructor de la clase. Inicializa los componentes de la interfaz de usuario.
3. **Métodos**:
   - `Forminterfaz_Load(object sender, EventArgs e)`: Este método se ejecuta cuando se carga el formulario. Agrega los niveles de mutación y grupos al `ComboBox` correspondiente y llama al método `iniciar()` para cargar los registros iniciales.

En esta clase, se definen varios métodos adicionales que no se muestran en el código proporcionado, como:

* `buttonLeer_Click(object sender, EventArgs e)`: Abre una nueva ventana `VistadeDatos` para mostrar todos los registros de personajes.
* `buttonCrear_Click(object sender, EventArgs e)`: Muestra un cuadro de diálogo de confirmación y, si el usuario confirma, crea un nuevo personaje con los datos ingresados en los controles de la interfaz y lo agrega a la base de datos.
* `blanquear()`: Limpia los campos de texto y controles de la interfaz.
* `iniciar()`: Limpia los controles, obtiene todos los usuarios de la base de datos y muestra el primer registro.
* `buttonObtenerTodos_Click(object sender, EventArgs e)`: Limpia los controles de la interfaz.
* `buttonsiguiente_Click(object sender, EventArgs e)`: Muestra el siguiente registro de personaje en la interfaz.
* `buttonanterior_Click(object sender, EventArgs e)`: Muestra el registro anterior de personaje en la interfaz.
* `buttonActualizar_Click(object sender, EventArgs e)`: Actualiza los datos del personaje actual en la base de datos con los valores ingresados en los controles de la interfaz.
* `buttonbuscar_Click(object sender, EventArgs e)`: Busca y muestra un personaje en la interfaz según el ID ingresado.
* `MostrarEncontrado(usuario usr)`: Muestra los datos de un personaje en los controles de la interfaz.
* `buttonEliminar_Click(object sender, EventArgs e)`: Muestra un cuadro de diálogo de confirmación y, si el usuario confirma, elimina el personaje actual de la base de datos.
* `pictureBox2_Click(object sender, EventArgs e)`: Hace visible un `PictureBox` llamado `pictureBoxKirby`.

La clase `Forminterfaz` representa la interfaz principal del programa XmenFinal y contiene la lógica para realizar operaciones CRUD (Crear, Leer, Actualizar, Eliminar) sobre los registros de personajes, así como para navegar entre ellos y mostrar sus datos en la interfaz.

ConexionXmen
La clase `ConexionXmen` es responsable de gestionar la conexión con la base de datos MySQL y realizar operaciones CRUD (Crear, Leer, Actualizar, Eliminar) sobre la tabla `xmen_lista`. Contiene los siguientes métodos principales:

1. `ProbarConexion()`: Verifica si la conexión con la base de datos MySQL es exitosa.
2. `LeerPersonajes()`: Obtiene todos los registros de personajes de la tabla `xmen_lista` y los retorna en un objeto `DataTable`.
3. `InsertarImagen(PictureBox foto)`: Inserta una imagen en la tabla `xmen_lista`. Recibe un objeto `PictureBox` que contiene la imagen a insertar.
4. `Insertar(usuario usr)`: Inserta un nuevo registro de usuario en la tabla `xmen_lista`. Recibe un objeto `usuario` con los datos a insertar.
5. `Actualizar(usuario usr)`: Actualiza un registro existente de usuario en la tabla `xmen_lista`. Recibe un objeto `usuario` con los datos actualizados.
6. `Borrar(usuario usr)`: Elimina un registro de usuario de la tabla `xmen_lista`. Recibe un objeto `usuario` con el ID del registro a eliminar. Retorna el número de filas afectadas por la operación.
7. `BuscarMutante(usuario usr)`: Busca un registro de usuario en la tabla `xmen_lista` por su ID. Recibe un objeto `usuario` con el ID a buscar. Retorna un objeto `DataTable` con los datos encontrados.
8. `BuscarPorId(int id)`: Busca un registro de usuario en la tabla `xmen_lista` por su ID. Recibe un entero con el ID a buscar. Retorna un objeto `usuario` con los datos encontrados, o `null` si no se encuentra.
9. `ObtenerTodosLosUsuarios()`: Obtiene todos los registros de usuarios de la tabla `xmen_lista` y los retorna en una Lista de objetos `usuario`.
10. `Eliminar(int id)`: Elimina un registro de usuario de la tabla `xmen_lista` por su ID. Recibe un entero con el ID del registro a eliminar.

La clase utiliza la biblioteca `MySql.Data` para interactuar con la base de datos MySQL. La cadena de conexión (`connectionString`) está definida como un atributo privado y contiene los detalles de conexión a la base de datos (servidor, nombre de la base de datos, usuario y contraseña).
Cada método realiza una operación específica en la base de datos, como insertar, actualizar, eliminar o buscar registros de usuarios. Los métodos utilizan objetos `MySqlConnection`, `MySqlCommand` y `MySqlDataReader` para ejecutar consultas SQL y trabajar con los datos obtenidos.

En resumen, Formprincipal es la pantalla de inicio, Forminterfaz es la interfaz principal para interactuar con los registros de personajes, y ConexionXmen es la clase que maneja la conexión y las operaciones de base de datos. Estas clases trabajan juntas para proporcionar una aplicación de escritorio completa que permite al usuario gestionar una base de datos de personajes de X-Men utilizando MySQL como sistema de gestión de base de datos.

Ayuda por favor., estoy cansado jefe ☹
