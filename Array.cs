<<<<<<< HEAD
﻿public interface IArray<T>
{
    public Array<T> GetElement(int[] indexes);
    public int[] GetPosition();
    public int GetRank();
    public int[] GetDimensions();
}
public interface IElement<T>
{
    public T GetValue();
    public void SetValue(T value);
}
public class Array<T>:IArray<T>,IElement<T>
{
    static int amount;
    private int inRankPosition = 0;
    int Depth;
    public T value;
    public T GetValue()
    {
        return value;
    }
    public void SetValue(T value)
    {
        this.value = value;
    }
    private int[] inheritedDimensions;
    private Array<T> parent;
    public Array<T>[] inherited;
    public Array(int[] dimensions, int depth = 0, Array<T> parent = null, int inRankPosition = 0)
    {
        if (parent == null)
            amount = 0;
        this.Depth = depth;
        this.parent = parent;
        this.inRankPosition = inRankPosition;
        if (dimensions.Length == 0) 
        {
            amount++;
            value = default;
            return;
        }    
        inherited = new Array<T>[dimensions[0]];
        if (dimensions.Length !=0)
        {
        inheritedDimensions = new int[dimensions.Length];
        }
        else
        {
            inheritedDimensions = null;
        }
        for (int i = 0; i < dimensions.Length; i++)
            inheritedDimensions[i] = dimensions[i];
        for(int i=0; i<inherited.Length;i++)
        {
            int[] newDims = new int[inheritedDimensions.Length - 1];
            for(int j=0;j<newDims.Length;j++)
            {
                newDims[j] = inheritedDimensions[j + 1];
            }
            inherited[i] = new Array<T>(newDims, depth + 1,this,i);
        }
        if(parent==null)
        Debug.Log($"Successfully built {amount} cells");
    }
    public Array<T> GetElement(int[] indexes)
    {
        Array<T> Ret = this;
        if(indexes.Length==inheritedDimensions.Length)
        {
            for (int i = 0; i < indexes.Length; i++) 
            {
                Ret = Ret.inherited[indexes[i]];
            }
            return Ret;
        }
        else
        {
            Debug.LogError($"Array dimension mismatch, returned null\nInput: int[{indexes.Length}], expected int[{inheritedDimensions.Length}]");
        }
        return null;
    }
    public int[] GetPosition()
    {
        Array<T> cell = this;
        //Debug.Log($"Rank is {cell.Depth}");
        int[] Ret = new int[cell.Depth];
            while(cell.Depth>0)
        {
            Ret[cell.Depth-1] = cell.inRankPosition;
            cell = cell.parent;
        }
        //Debug.Log($"Returned position: {string.Concat(Ret)}");
        return Ret;
    }
    public int[] GetDimensions()
    {
        return inheritedDimensions;
    }
    public int GetRank()
    {
        return inheritedDimensions.Length;
    }
    int[] Add(int[]array1,int[]array2)
    {
        if(array2==null)
        {
            return array1;
        }
        if(array1==null)
        {
            array1 = array2;
            return array1;
        }
        int[] buff = array1;
        array1 = new int[array1.Length + array2.Length];
        for (int i = 0; i < buff.Length; i++)
        {
            array1[i] = buff[i];
        }
        for (int i = 0; i < array2.Length; i++)
        {
            array1[i+buff.Length] = array2[i];
        }
        return array1;
    }
}
=======
﻿public interface IArray<T>
{
    public Array<T> GetElement(int[] indexes);
    public int[] GetPosition();
    public int GetRank();
    public int[] GetDimensions();
}
public interface IElement<T>
{
    public T GetValue();
    public void SetValue(T value);
}
public class Array<T>:IArray<T>,IElement<T>
{
    static int amount;
    private int inRankPosition = 0;
    int Depth;
    public T value;
    public T GetValue()
    {
        return value;
    }
    public void SetValue(T value)
    {
        this.value = value;
    }
    private int[] inheritedDimensions;
    private Array<T> parent;
    public Array<T>[] inherited;
    public Array(int[] dimensions, int depth = 0, Array<T> parent = null, int inRankPosition = 0)
    {
        if (parent == null)
            amount = 0;
        this.Depth = depth;
        this.parent = parent;
        this.inRankPosition = inRankPosition;
        if (dimensions.Length == 0) 
        {
            amount++;
            value = default;
            return;
        }    
        inherited = new Array<T>[dimensions[0]];
        if (dimensions.Length !=0)
        {
        inheritedDimensions = new int[dimensions.Length];
        }
        else
        {
            inheritedDimensions = null;
        }
        for (int i = 0; i < dimensions.Length; i++)
            inheritedDimensions[i] = dimensions[i];
        for(int i=0; i<inherited.Length;i++)
        {
            int[] newDims = new int[inheritedDimensions.Length - 1];
            for(int j=0;j<newDims.Length;j++)
            {
                newDims[j] = inheritedDimensions[j + 1];
            }
            inherited[i] = new Array<T>(newDims, depth + 1,this,i);
        }
        if(parent==null)
        Debug.Log($"Successfully built {amount} cells");
    }
    public Array<T> GetElement(int[] indexes)
    {
        Array<T> Ret = this;
        if(indexes.Length==inheritedDimensions.Length)
        {
            for (int i = 0; i < indexes.Length; i++) 
            {
                Ret = Ret.inherited[indexes[i]];
            }
            return Ret;
        }
        else
        {
            Debug.LogError($"Array dimension mismatch, returned null\nInput: int[{indexes.Length}], expected int[{inheritedDimensions.Length}]");
        }
        return null;
    }
    public int[] GetPosition()
    {
        Array<T> cell = this;
        //Debug.Log($"Rank is {cell.Depth}");
        int[] Ret = new int[cell.Depth];
            while(cell.Depth>0)
        {
            Ret[cell.Depth-1] = cell.inRankPosition;
            cell = cell.parent;
        }
        //Debug.Log($"Returned position: {string.Concat(Ret)}");
        return Ret;
    }
    public int[] GetDimensions()
    {
        return inheritedDimensions;
    }
    public int GetRank()
    {
        return inheritedDimensions.Length;
    }
    int[] Add(int[]array1,int[]array2)
    {
        if(array2==null)
        {
            return array1;
        }
        if(array1==null)
        {
            array1 = array2;
            return array1;
        }
        int[] buff = array1;
        array1 = new int[array1.Length + array2.Length];
        for (int i = 0; i < buff.Length; i++)
        {
            array1[i] = buff[i];
        }
        for (int i = 0; i < array2.Length; i++)
        {
            array1[i+buff.Length] = array2[i];
        }
        return array1;
    }
}
>>>>>>> 804f20ec90c4e390759b250909d07dee5b16f199
