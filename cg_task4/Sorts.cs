using System.Collections.Generic;

namespace cg_task4
{
    public static class Sorts
    {
        public static Action[] StoogeSort(int[] arr)
        {
            List<Action> list = new List<Action>();
            StoogeSort(arr, 0, arr.Length - 1, list);
            return list.ToArray();
        }

        private static void StoogeSort(int[] arr, int l, int r, List<Action> actions)
        {
            if (l >= r)
                return;

            actions.Add(new Action(Operation.SELECT, l, r));
            if (arr[l] > arr[r])
            {
                actions.Add(new Action(Operation.SWAP, l, r));
                int t = arr[l];
                arr[l] = arr[r];
                arr[r] = t;
            }
            actions.Add(new Action(Operation.DESELECT, l, r));

            if (r - l + 1 > 2)
            {
                int t = (r - l + 1) / 3;
                StoogeSort(arr, l, r - t, actions);
                StoogeSort(arr, l + t, r, actions);
                StoogeSort(arr, l, r - t, actions);
            }
        }
    }
}
