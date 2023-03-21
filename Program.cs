using System.Collections.Generic;
Dictionary<string,int> diccionarioCursos = new Dictionary<string, int>();
string curso = " ";
Console.WriteLine("1 Ingrese los importes del curso");
Console.WriteLine("2 Ver estadisticas");
int eleccion = IngresarInt("Ingrese la opcion que desea realizar, si desea salir ingrese 0","Error, el valor ingresado no es numerico,reingreselo");
int dinero = 0;


while(eleccion != 0)
{
    switch(eleccion)
{
    case 1:
    dinero = IngresarCursoxEstudiantes(ref curso);
    diccionarioCursos.Add(curso,dinero);
    break;
    case 2:
    MostrarEstadisticas( diccionarioCursos);
    break;
}
Console.WriteLine("1 Ingrese los importes del curso");
Console.WriteLine("2 Ver estadisticas");
eleccion = IngresarInt("Ingrese la opcion que desea realizar, si desea salir ingrese 0","Error, el valor ingresado no es numerico,reingreselo");
}


int IngresarCursoxEstudiantes(ref string curso)
{
    int cantEstudiantes,plata = 0;
    curso = IngresarString("Ingrese el curso");
    if(diccionarioCursos.ContainsKey(curso))
    {
        curso = IngresarString("El curso ingresado, ya fue ingresado, ingrese otro");
    }
    cantEstudiantes = IngresarInt("Ingrese la cantidad de alumnos que tiene el curso","Error, ingrese un valor numerico mayor a 0");
    for(int i = 0; i < cantEstudiantes; i++)
    {
        plata += IngresarInt("Ingrese el importe que desea aportar al regalo el alumno " + i ,"Error,ingrese un valor numerico mayor a 0");
       
    }
    return plata;
}


int IngresarInt(string mensaje,string mensaje1)
{
    string num = " ";
    int numero = -1;
    bool sePuede = true;
    Console.WriteLine(mensaje);
    num = Console.ReadLine();
    sePuede = int.TryParse(num,out numero);
    while(sePuede == false && numero <= 0)
    {
        Console.WriteLine(mensaje1);
        num = Console.ReadLine();
        sePuede = int.TryParse(num,out numero);
    }
    return numero;
}
string IngresarString(string mensaje)
{
    Console.WriteLine(mensaje);
    return Console.ReadLine();
}

void MostrarEstadisticas(Dictionary<string,int> diccionarioCursos)
{
    int plataMax = 0,promedio = 0,recaudacionTotal = 0;
    string cursoMax = " ";

    if(diccionarioCursos.Count > 0)
    {foreach(string curso in diccionarioCursos.Keys)
    {
        if(plataMax < diccionarioCursos[curso])
        {
            plataMax = diccionarioCursos[curso];
            cursoMax = curso;
        }


        recaudacionTotal += diccionarioCursos[curso];
    }
    promedio = recaudacionTotal / diccionarioCursos.Count;


    Console.WriteLine("EL curso que mas plata dio fue el curso " + cursoMax);

    Console.WriteLine("La cantidad de cursos que participan en el regalo son " + diccionarioCursos.Count);

    Console.WriteLine("El promedio regalado por todos los cursos es de $" + promedio);

    Console.WriteLine("La recaudacion total entre todos los cursos fue de $" + recaudacionTotal);
    }
    else
    {
        Console.WriteLine("No se ha ingresado informacion aun");
        Console.ReadLine();
    }
    
}
