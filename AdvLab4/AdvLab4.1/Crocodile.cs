namespace AdvLab4._1
{
    public class Crocodile
    {
        int _scales, _weight,_id;

        

        public Crocodile(int id , int scales, int weight)
        {
            _scales = scales;
            _weight = weight;
            _id = id;
        }

        public int ID
        {
            get { return _id; }
        }

        public int Scales
        {
            get { return _scales; }
            set { _scales = value; }
        }

        public int Weight
        {
            get { return _weight; }
            set { _weight = value; }
        }

        public override string ToString()
        {
            return $"Crocodile data: ID: {ID} Scales: {Scales}   Weight: {Weight}";
        }
    }
}