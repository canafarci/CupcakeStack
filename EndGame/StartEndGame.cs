using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using AmazingAssets.CurvedWorld;
using System.Linq;
using System;
using AmazingAssets.CurvedWorld.Example;

public class StartEndGame : MonoBehaviour
{
    AmazingAssets.CurvedWorld.ChunkSpawner _worldController;
    public event Action OnEndGameStart;
    private void Awake() => _worldController = FindObjectOfType<AmazingAssets.CurvedWorld.ChunkSpawner>();

    public void EndGameStart()
    {
        StartCoroutine(StartFinalStage());
    }

    IEnumerator StartFinalStage()
    {
        OnEndGameStart?.Invoke();

        yield return new WaitForSeconds(.2f);

        MoveHorizontal moveHorizontal = FindObjectOfType<MoveHorizontal>();
        moveHorizontal.RemoveControl();
        moveHorizontal.CenterPosition();

        FindObjectOfType<Stacker>().ItemList.ForEach(x => x.CenterPosition());

        FindObjectOfType<FinalStageTrigger>().MaxStackCount = FindObjectOfType<Stacker>().ItemList.Count;
    }

    /* IEnumerator StartFinalStage()
    {
        OnEndGameStart?.Invoke();

        DOTween.To(() => _worldController.bendVerticalSize, x => _worldController.bendVerticalSize = x, 0, 1);

        if (!_isSecondEnding)
        {
            
            FindObjectOfType<ChunkSpawner>().movingSpeed = 0f;


            StackMover stackMover = FindObjectOfType<StackMover>();
            Stacker stacker = FindObjectOfType<Stacker>();

            foreach (StackableBall sb in FindObjectOfType<Stacker>().BallList)
            {
                sb.transform.GetComponentInChildren<Animator>().enabled = false;
            }

            followRoad.RemoveControl();
            

            yield return new WaitForSeconds(1.2f);

            stackMover.PauseStacker();

            Transform mainBall = stacker.BallList.Last().transform;
            Transform player = stacker.transform;
            List<StackableBall> list = stacker.BallList;
            list.Remove(stacker.BallList.Last());
            list.Reverse();

            

            StartCoroutine(ScaleFinalStage(mainBall));
            foreach (StackableBall sb in list)
            {
                sb.GetComponent<Collider>().enabled = false;
                Destroy(sb.GetComponent<Rigidbody>());
                Destroy(sb.GetComponent<RunnerCar>());
                sb.transform.DOMove(mainBall.transform.position, .3f);
                yield return new WaitForSeconds(.3f);
                

            }

            player.GetComponent<Collider>().enabled = false;
            Destroy(player.GetComponent<Rigidbody>());
            Destroy(player.GetComponent<RunnerCar>());
            player.transform.DOMove(mainBall.transform.position, .3f);
            yield return new WaitForSeconds(.3f);
            player.transform.parent = mainBall;

            yield return new WaitForSeconds(1f);

            mainBall.gameObject.AddComponent<InputReader>();
            mainBall.gameObject.AddComponent<MoveHorizontal>();
            mainBall.gameObject.AddComponent<EndGameMover>();

            PinDamage damager =  mainBall.gameObject.AddComponent<PinDamage>();
            damager.IsSecondEnding = false;

            mainBall.transform.GetComponentInChildren<Animator>().enabled = true;

            OnEndGamePinReferences?.Invoke(damager);

        }
        else
        {
            PinDamage damager = FindObjectOfType<MoveHorizontal>().gameObject.AddComponent<PinDamage>();
            damager.IsSecondEnding = true;
            OnEndGamePinReferences?.Invoke(damager);
        }
    }

    IEnumerator ScaleFinalStage(Transform mainBall)
    {
        int index = 1;
        yield return new WaitForSeconds(.2f);

        EndGameCamera camera = FindObjectOfType<EndGameCamera>();
        ParticleSystem[] fxs = mainBall.GetComponentsInChildren<ParticleSystem>();    

        foreach (StackableBall sb in FindObjectOfType<Stacker>().BallList)
        {
            
            Vector3 targetScale = new Vector3(1f + 1f * _scaleFactor * index, 1f + 1f * _scaleFactor * index, 1f + 1f * _scaleFactor * index);

            mainBall.DOScale(targetScale, .18f);

            Vector3 pos = mainBall.position;

            pos.y = 0.9f * mainBall.localScale.y;
            mainBall.position = pos;
            foreach (ParticleSystem fx in fxs)
            {
                fx.Play();
            }

            yield return new WaitForSeconds(.3f);
            sb.transform.parent = mainBall;
            sb.gameObject.SetActive(false);
            camera.ScaleCamera();
            index++;
        }
    } */
}
