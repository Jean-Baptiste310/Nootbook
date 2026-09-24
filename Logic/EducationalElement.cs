namespace Logic
{
    public class EducationalElement
    {
        private string name;

        public string Name
        {
            get { return name; }
            set {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("The name cannot be null or empty");
                }
                name = value; 
            }
        }
        private float coef;
        public float Coef
        {
            get { return  coef; }
            set {  
                if (value <= 0)
                {
                    throw new Exception("The coef must be >0");
                }
                coef = value; 
            }
        }

        public override string ToString()
        {
            return name + " (" + coef.ToString() + ")";
        }

    }
}
