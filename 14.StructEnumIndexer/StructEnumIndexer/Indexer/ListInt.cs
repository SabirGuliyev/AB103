using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructEnumIndexer.Indexer
{
    internal class ListInt
    {
        private int[] _arr;

        public int this[int index] 
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



        public ListInt()
        {
            _arr = new int[0];
        }
        public ListInt(int length)
        {
            _arr=new int[length];
        }
        public ListInt(params int[] nums)
        {
            _arr = new int[nums.Length];

            for (int i = 0; i < nums.Length; i++)
            {
                _arr[i] = nums[i];
            }
        }


        public void Add(int num)
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
