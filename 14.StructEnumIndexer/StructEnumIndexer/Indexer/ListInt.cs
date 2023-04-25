using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructEnumIndexer.Indexer
{
    internal class CusList<T>
    {
        private T[] _arr;

        public T this[int index] 
        { 
            get
            {
                if (index<_arr.Length)
                {
                    return _arr[index];
                }
                else
                {
                    return _arr[_arr.Length - 1];
                }
              
            }
            set
            {
                if (_arr.Length>index)
                {
                    _arr[index] = value;
                }
           
            }  
        }

        public int Length { 
            get 
            {

                return _arr.Length;
            } 
           }



        public CusList()
        {
            _arr = new T[0];
        }
        public CusList(int length)
        {
            _arr=new T[length];
        }
        public CusList(params T[] nums)
        {
            _arr = new T[nums.Length];

            for (int i = 0; i < nums.Length; i++)
            {
                _arr[i] = nums[i];
            }
        }


        public void Add(T num)
        {
            Array.Resize(ref _arr, _arr.Length+1);
            _arr[_arr.Length-1] = num;
        }
        public void Remove()
        {
            Array.Resize(ref _arr, _arr.Length-1);
        }
    }
}
