using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    public class MeteoriteBall : Ball
    {        
        public MeteoriteBall(MatrixCoords coords, MatrixCoords speed)
            : base(coords, speed)
        {
            base.body = new char[,] { {'O'} };
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            List<GameObject> producedObjects = new List<GameObject>();
            producedObjects.Add(new TrailObject(this.GetTopLeft(), 3));
            return producedObjects;
        }
    }
}