int numero = int.Parse(Console.ReadLine()!);

string diaDaSemana = numero switch 
{
    1 => "Domingo",
    2 => "Segunda",
    3 => "Terça",
    _ => "Dia inválido"
};
Console.WriteLine(diaDaSemana);







