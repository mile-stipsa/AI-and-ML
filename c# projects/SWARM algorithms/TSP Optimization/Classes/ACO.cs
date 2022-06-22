
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSP_Optimization.Classes
{
    public class ACO
    {
        #region Attributes

        private int beta;
        private int alpha;

        private double rho;
        private double Q;

        private int number_of_cities;
        private int number_of_ants;

        private int[][] distances;
        private int[][] ants;
        private double[][] pheromones;

        #endregion

        #region Constructors

        public ACO(int city, int ant, int alp, int bet,double dec, double inc)
        {
            this.number_of_cities = city;
            this.number_of_ants = ant;
            this.alpha = alp;
            this.beta = bet;
            this.rho = dec;
            this.Q = inc;
        }

        #endregion

        #region Functions ants and pheromones

        public void initialize_ants(Random rnd)
        {
            this.ants = new int[this.number_of_ants][];
            for (int k = 0; k <= this.number_of_ants - 1; k++)
            {
                int start = rnd.Next(0, this.number_of_cities);
                this.ants[k] = this.random_trail(start, rnd);
            }
        }

        public void update_ants(Random rnd)
        {
            int number_cities = this.pheromones.Length;
            for (int k = 0; k <= this.ants.Length - 1; k++)
            {
                int start = rnd.Next(0, number_cities);
                int[] newTrail = this.build_trail(k, start, rnd);
                this.ants[k] = newTrail;
            }
        }

        public void initialize_pheromones()
        {
            this.pheromones = new double[this.number_of_cities][];
            for (int i = 0; i <= this.number_of_cities - 1; i++)
            {
                this.pheromones[i] = new double[this.number_of_cities];
            }

            for (int i = 0; i <= this.pheromones.Length - 1; i++)
            {
                for (int j = 0; j <= this.pheromones[i].Length - 1; j++)
                {
                    this.pheromones[i][j] = 0.01;
                }
            }
        }

        public void update_pheromones()
        {
            for (int i = 0; i <= this.pheromones.Length - 1; i++)
            {
                for (int j = i + 1; j <= this.pheromones[i].Length - 1; j++)
                {
                    for (int k = 0; k <= this.ants.Length - 1; k++)
                    {
                        double length = this.length(this.ants[k]);
                        // length of ant k trail
                        double decrease = (1.0 - rho) * this.pheromones[i][j];
                        double increase = 0.0;
                        if (this.edge_in_the_trail(i, j,this.ants[k]) == true)
                        {
                            increase = (Q / length);
                        }

                        pheromones[i][j] = decrease + increase;

                        if (pheromones[i][j] < 0.0001)
                        {
                            pheromones[i][j] = 0.0001;
                        }
                        else if (pheromones[i][j] > 100000.0)
                        {
                            pheromones[i][j] = 100000.0;
                        }

                        pheromones[j][i] = pheromones[i][j];
                    }
                }
            }
        }

        #endregion

        #region Others functions

        private int[] random_trail(int start, Random rnd)
        {
            int[] trail = new int[this.number_of_cities];

            for (int i = 0; i <= this.number_of_cities - 1; i++)
            {
                trail[i] = i;
            }

            for (int i = 0; i <= this.number_of_cities - 1; i++)
            {
                int r = rnd.Next(i, this.number_of_cities);
                int tmp = trail[r];
                trail[r] = trail[i];
                trail[i] = tmp;
            }

            int idx = this.index_of_target(trail, start);

            int temp = trail[0];
            trail[0] = trail[idx];
            trail[idx] = temp;

            return trail;
        }

        private int[] build_trail(int k, int start, Random rnd)
        {
            int number_cities = pheromones.Length;
            int[] trail = new int[number_cities];
            bool[] visited = new bool[number_cities];
            trail[0] = start;
            visited[start] = true;
            for (int i = 0; i <= number_cities - 2; i++)
            {
                int cityX = trail[i];
                int next = this.next_city(k, cityX, visited, rnd);
                trail[i + 1] = next;
                visited[next] = true;
            }
            return trail;
        }

        private int next_city(int k, int cityX, bool[] visited, Random rnd)
        {
            // for ant k (with visited[]), at nodeX, what is next node in trail?
            double[] probs = move_probs(k, cityX, visited);

            double[] cumul = new double[probs.Length + 1];
            for (int i = 0; i <= probs.Length - 1; i++)
            {
                cumul[i + 1] = cumul[i] + probs[i];
                // consider setting cumul[cuml.Length-1] to 1.00
            }

            double p = rnd.NextDouble();

            for (int i = 0; i <= cumul.Length - 2; i++)
            {
                if (p >= cumul[i] && p < cumul[i + 1])
                {
                    return i;
                }
            }
            throw new Exception("Failure to return valid city in next_city");
        }

        private double[] move_probs(int k, int cityX, bool[] visited)
        {
            // for ant k, located at nodeX, with visited[], return the prob of moving to each city
            int number_cities = this.pheromones.Length;
            double[] taueta = new double[number_cities];
            // inclues cityX and visited cities
            double sum = 0.0;
            // sum of all tauetas
            // i is the adjacent city
            for (int i = 0; i <= taueta.Length - 1; i++)
            {
                if (i == cityX)
                {
                    taueta[i] = 0.0;
                    // prob of moving to self is 0
                }
                else if (visited[i] == true)
                {
                    taueta[i] = 0.0;
                    // prob of moving to a visited city is 0
                }
                else
                {
                    taueta[i] = Math.Pow(pheromones[cityX][i], alpha) * Math.Pow((1.0 / distances[cityX] [i]), beta);
                    // could be huge when pheromone[][] is big
                    if (taueta[i] < 0.0001)
                    {
                        taueta[i] = 0.0001;
                    }
                    else if (taueta[i] > (double.MaxValue / (number_cities * 100)))
                    {
                        taueta[i] = double.MaxValue / (number_cities * 100);
                    }
                }
                sum += taueta[i];
            }

            double[] probs = new double[number_cities];
            for (int i = 0; i <= probs.Length - 1; i++)
            {
                probs[i] = taueta[i] / sum;
                // big trouble if sum = 0.0
            }
            return probs;
        }

        private int index_of_target(int[] trail,int target)
        {
            for (int i = 0; i <= trail.Length - 1; i++)
            {
                if (trail[i] == target)
                {
                    return i;
                }
            }
            throw new Exception("Target not found in index_of_target");
        }

        public double length(int[] trail)
        {
            double result = 0.0;
            for (int i = 0; i <= trail.Length - 2; i++)
            {
                result += this.distances[trail[i]][trail[i + 1]];
            }
            return result;
        }

        public int[] best_trail()
        {
            double best_length = this.length(ants[0]);
            int idx_best_length = 0;
            for (int k = 1; k <= this.ants.Length - 1; k++)
            {
                double len = this.length(ants[k]);
                if (len < best_length)
                {
                    best_length = len;
                    idx_best_length = k;
                }
            }

            return this.ants[idx_best_length];
        }

        private bool edge_in_the_trail(int cityX, int cityY, int[] trail)
        {
            // are cityX and cityY adjacent to each other in trail[]?
            int lastIndex = trail.Length - 1;
            int idx = this.index_of_target(trail, cityX);

            if (idx == 0 && trail[1] == cityY)
            {
                return true;
            }
            else if (idx == 0 && trail[lastIndex] == cityY)
            {
                return true;
            }
            else if (idx == 0)
            {
                return false;
            }
            else if (idx == lastIndex && trail[lastIndex - 1] == cityY)
            {
                return true;
            }
            else if (idx == lastIndex && trail[0] == cityY)
            {
                return true;
            }
            else if (idx == lastIndex)
            {
                return false;
            }
            else if (trail[idx - 1] == cityY)
            {
                return true;
            }
            else if (trail[idx + 1] == cityY)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void make_graph_distances(Random rnd)
        {
            this.distances = new int[this.number_of_cities][];
            for (int i = 0; i <= this.distances.Length - 1; i++)
            {
                this.distances[i] = new int[this.number_of_cities];
            }
            for (int i = 0; i <= this.number_of_cities - 1; i++)
            {
                for (int j = i + 1; j <= this.number_of_cities - 1; j++)
                {
                    int d = rnd.Next(1, 9);
                    // [1,8]
                    this.distances[i][j] = d;
                    this.distances[j][i] = d;
                }
            }
           
        }

        #endregion

        #region Print functions

        public string Display(int[] trail)
        {
            StringBuilder str = new StringBuilder();
            for (int i = 0; i <= trail.Length - 1; i++)
            {
                if(i!=trail.Length-1)
                    str.Append(trail[i] + "->");
                else
                    str.Append(trail[i]);
            }
            return str.ToString();
        }

        #endregion
    }
}
