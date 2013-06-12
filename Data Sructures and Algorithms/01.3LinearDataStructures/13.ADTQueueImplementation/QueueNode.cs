namespace _13.ADTQueueImplementation
{
    public class QueueNode<T>
    {
        private T value;

        private QueueNode<T> nextItem;

        public QueueNode<T> NextItem
        {
            get 
            { 
                return this.nextItem; 
            }

            set 
            { 
                this.nextItem = value; 
            }
        }

        public T Value
        {
            get 
            { 
                return this.value; 
            }

            set 
            { 
                this.value = value; 
            }
        }
    }
}
