using UnityEngine;
using CodeMonkey.Utils;

public class TestScript : MonoBehaviour
{
    private void Start()
    {
        Pathfinding pathfinding = new Pathfinding(10, 10);
    }

}

/*public class TestScript : MonoBehaviour
{
    private Grid<int> grid;

    private void Start()
    {
        grid = new Grid<int>(4, 2, 10f, new Vector3(20,0));
    }


    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            grid.SetValue(UtilsClass.GetMouseWorldPosition(), 56 );
        }

        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log(grid.GetValue(UtilsClass.GetMouseWorldPosition()));
        }
    }
}*/
