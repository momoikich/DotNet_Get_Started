using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Bienvenue dans le jeu de devinette !");
        
        // Générer un nombre aléatoire entre 1 et 100
        Random random = new Random();
        int numberToGuess = random.Next(1, 101);
        
        int attempts = 0;
        bool hasGuessedCorrectly = false;

        Console.WriteLine("Devinez le nombre entre 1 et 100.");

        do
        {
            Console.Write("Votre proposition : ");
            string userInput = Console.ReadLine();

            // Vérifier si l'entrée est un nombre entier
            if (int.TryParse(userInput, out int userGuess))
            {
                attempts++;

                if (userGuess == numberToGuess)
                {
                    hasGuessedCorrectly = true;
                    Console.WriteLine($"Félicitations ! Vous avez deviné le nombre {numberToGuess} en {attempts} essais.");
                }
                else if (userGuess < numberToGuess)
                {
                    Console.WriteLine("Le nombre à deviner est plus grand. Essayez à nouveau.");
                }
                else
                {
                    Console.WriteLine("Le nombre à deviner est plus petit. Essayez à nouveau.");
                }
            }
            else
            {
                Console.WriteLine("Veuillez entrer un nombre valide.");
            }

        } while (!hasGuessedCorrectly);

        Console.WriteLine("Merci d'avoir joué !");
    }
}





