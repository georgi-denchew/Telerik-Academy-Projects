namespace _11.LinkedListImplementation
{
    public class ListItem<T>
    {
        private T value;

        private ListItem<T> nextItem;
        
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

        public ListItem<T> NextItem
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
    }
}
