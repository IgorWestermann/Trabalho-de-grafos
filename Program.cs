﻿using System.Text;
using TrabalhoGrafos.Graph;
using TrabalhoGrafos.Graph.Models;


class Program
{
    public static void Main()
    {
        var graph = new GraphUtils(0);
        var graphType = String.Empty;
        int choice, choiceTwo;
        var grafo = new Grafo();

        do
        {
            Console.WriteLine("Menu");
            Console.WriteLine("1. Grafo Simples Não Valorado");
            Console.WriteLine("2. Grafo Simples Valorado");
            Console.WriteLine("3. Grafo Direcionado Valorado");
            Console.WriteLine("4. Exit");

            Console.Write("Escolha um número (1-4)");
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        graphType = "GrafoSimples";
                        break;
                    case 2:
                        graphType = "GrafoSimplesValorado";
                        break;
                    case 3:
                        graphType = "DigrafoSimplesValorado";
                        break;
                    case 4:
                        Console.WriteLine("Saindo");
                        break;
                    default:
                        Console.WriteLine("Número inválido. Escolha um número(1-4)");
                        continue;
                }

                graph.ReadGraph($"./../../../{graphType}.txt", choice);

                Console.WriteLine("\nOperações:");
                Console.WriteLine("5. Transformar em Matriz de Incidência");
                Console.WriteLine("6. Transformar em Matriz de Distancia");
                Console.WriteLine("7. Transformar em Lista de Adjacencia");
                Console.WriteLine("8. Busca em Largura (BFS)");
                Console.WriteLine("9. Busca em Profundidade (DFS)");
                Console.WriteLine("10. Dijkstra");
                Console.WriteLine("11. Prim");
                Console.WriteLine("12. Ordenação Topologica");
                Console.WriteLine("13. Ciclo Euleriano");
                Console.WriteLine("99. Voltar");

                Console.Write("Encolha um número (5-13)");
                if (int.TryParse(Console.ReadLine(), out choiceTwo))
                {
                    var initialVertex = new int();
                    var finalVertex = new int();

                    switch (choiceTwo)
                    {
                        case 5:
                            GraphUtils.DisplayIncidenceTable(graph.TransformToIncidenceMatrix());
                            break;
                        
                        case 6:
                            GraphUtils.DisplayAdjacencyMatrix(graph.TransformToDistanceMatrix());
                            break;
                        
                        case 7:
                            GraphUtils.DisplayAdjacencyList(graph.TransformToAdjacencyList(choice));
                            break;
                        
                        case 8:
                            Console.WriteLine("Escolha o vertice inicial");

                            initialVertex = int.Parse(Console.ReadLine());
                            graph.ExecuteBFS(initialVertex, grafo.CriarGrafo(graph.AdjacencyMatrix));

                            break;
                        case 9:
                            Console.WriteLine("Escolha o vertice inicial");

                            initialVertex = int.Parse(Console.ReadLine());
                            grafo.CriarGrafo(graph.AdjacencyMatrix);
                            graph.ExecuteDFS(initialVertex, grafo);

                            break;
                        case 10:
                            Console.WriteLine("Escolha o vertice inicial");
                            initialVertex = int.Parse(Console.ReadLine());

                            graph.ExecuteDijkstra(graph.AdjacencyMatrix, initialVertex);
                            break;
                        case 11:
                            graph.ExecutePrim(grafo);
                            break;
                        case 12:
                            graph.ExecuteTopologicalSort(grafo.CriarGrafo(graph.AdjacencyMatrix));
                            break;
                        case 13:
                            graph.ExecuteEulerianCycle(grafo);
                            break;
                        default:
                            Console.WriteLine("Escolha um número (5-14)");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Número inválido");
                }
            }
            else
            {
                Console.WriteLine("Número inválido");
            }
            graph = new GraphUtils(0);
            grafo = new Grafo();
        } while (choice != 99);
    }
}