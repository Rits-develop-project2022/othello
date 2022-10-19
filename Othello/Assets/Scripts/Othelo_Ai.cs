using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Barracuda;

public class OtheloAI: MonoBehaviour
{

    
    public NNModel modelSource;

    //[SerializeField, Tooltip("入力する文字画像")]
    //private Texture2D m_InputTexture;

    // Start is called before the first frame update
    void Start()
    {
        // 動作確認のサンプルなので, すべて Start() 上で実行しています.

        // モデルのロード

        var model = ModelLoader.Load(modelSource);

        // ワーカー (推論エンジン) の作成
        var worker = BarracudaWorkerFactory.CreateWorker(BarracudaWorkerFactory.Type.ComputePrecompiled, model);

        // 入力の作成. 第2引数はチャンネル数.
        //var tensor = new Tensor(m_InputTexture, 1);
        
        var tensor = new Tensor(1,8,8,1);

        for (var y = 0; y < 8; y++)
        {
            for (var x = 0; x < 8; x++)
            {
                
                tensor[0, 7 - y, x, 0] = 0;
            }
        }

        tensor[0,3,3,0] = -1;
        tensor[0,3,4,0] = 1;
        tensor[0,4,3,0] = 1;
        tensor[0,4,4,0] = -1;

        // tensor = new int[,,,] {{
        //     {{ 0},
        //     { 0},
        //     { 0},
        //     { 0},
        //     { 0},
        //     { 0},
        //     { 0},
        //     { 0}},

        //     {{ 0},
        //     { 0},
        //     { 0},
        //     { 0},
        //     { 0},
        //     { 0},
        //     { 0},
        //     { 0}},

        //     {{ 0},
        //     { 0},
        //     { 0},
        //     { 0},
        //     { 0},
        //     { 0},
        //     { 0},
        //     { 0}},

        //     {{ 0},
        //     { 0},
        //     { 0},
        //     {-1},
        //     { 1},
        //     { 0},
        //     { 0},
        //     { 0}},

        //     {{ 0},
        //     { 0},
        //     { 0},
        //     { 1},
        //     {-1},
        //     { 0},
        //     { 0},
        //     { 0}},

        //     {{ 0},
        //     { 0},
        //     { 0},
        //     { 0},
        //     { 0},
        //     { 0},
        //     { 0},
        //     { 0}},

        //     {{ 0},
        //     { 0},
        //     { 0},
        //     { 0},
        //     { 0},
        //     { 0},
        //     { 0},
        //     { 0}},
            
        //     {{ 0},
        //     { 0},
        //     { 0},
        //     { 0},
        //     { 0},
        //     { 0},
        //     { 0},
        //     { 0}}}};
        

        // 推論の実行
        worker.Execute(tensor);

        // 推論結果の取得
        var O = worker.Peek();


        // 結果の表示
        int pred = 0;
        float maxVal = float.MinValue;
        for (int i = 0; i < 64; ++i)
        {
            if (maxVal < O.readonlyArray[i])
            {
                pred = i;
                maxVal = O.readonlyArray[i];
            }
        }
        Debug.Log("Pred: " + pred.ToString());

        // 後片付け (メモリの解放など)
        O.Dispose();
        worker.Dispose();
        }

        // Update is called once per frame
        void Update()
        {

        }
}