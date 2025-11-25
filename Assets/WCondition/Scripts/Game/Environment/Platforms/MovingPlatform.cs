using System.Collections;
using DG.Tweening;
using UnityEngine;
public class MovingPlatform : MonoBehaviour, IGameAciton
{
    [Header("Waypoints Settings")]
    public Transform[] _waypoints;
    public Transform _platform;
    public float _moveSpeed = 3f;
    public bool _isLoop = true;
    public bool _isPingPong = false;
    public bool _isAutoStart = true;
    public Ease ease = Ease.OutCubic;

    private int _currentIndex = 0;
    private bool _movingForward = true;
    private Coroutine _moveRoutine;
    private float arriveThreshold = 0.05f;

    private Sequence _moveSequence;

    //Add Counts of max invokes;
    void Start()
    {
        if (_waypoints == null || _waypoints.Length < 2)
            return;
            
        _currentIndex = 0;
        arriveThreshold = 0.05f;

        if (_isAutoStart)
            InvokeGameAction();
    }
    public void InvokeGameAction()
    {
        if (_moveSequence != null && _moveSequence.IsActive())
            _moveSequence.Kill();

        _moveSequence = DOTween.Sequence();
        _moveSequence.SetAutoKill(false);
        //_moveRoutine = StartCoroutine(MoveLoop());
        for (int i = 0; i < _waypoints.Length; i++)
        {
            Vector3 targetPos = _waypoints[i].position;

            // Time = distance / speed
            float dist = Vector3.Distance(
                i == 0 ? _platform.position : _waypoints[i - 1].position,
                targetPos
            );

            float duration = dist / _moveSpeed;

            _moveSequence.Append(
                _platform.DOMove(targetPos, duration).SetEase(ease)
            );
        }

        // Looping behavior
        if (_isPingPong)
        {
            _moveSequence.SetLoops(-1, LoopType.Yoyo);
            
        }
        else
        {
            if (_isLoop)
                _moveSequence.SetLoops(-1, LoopType.Restart);
        }

        _moveSequence.Play();
    }

    IEnumerator MoveLoop()
    {
        while (true)
        {
            Debug.Log(_currentIndex);
            Transform target = _waypoints[_currentIndex];

            // Move until we reach the target waypoint
            while (Vector3.Distance(_platform.position, target.position) > arriveThreshold)
            {
                _platform.position = Vector3.MoveTowards(
                    _platform.position,
                    target.position,
                    _moveSpeed * Time.deltaTime);

                yield return null; // wait next frame
            }

            NextWaypoint();
            yield return null;
        }
    }

    void NextWaypoint()
    {
        if (_isPingPong)
        {
            if (_movingForward)
            {
                _currentIndex++;
                if (_currentIndex >= _waypoints.Length)
                {
                    _currentIndex = _waypoints.Length - 2;
                    _movingForward = false;
                }
            }
            else
            {
                _currentIndex--;
                if (_currentIndex < 0)
                {
                    _currentIndex = 1;
                    _movingForward = true;
                }
            }
        }
        else
        {
            _currentIndex++;
            if (_currentIndex >= _waypoints.Length)
            {
                _currentIndex = 0;
                if (!_isLoop)
                    StopCoroutine(_moveRoutine);
            }
        }
    }

    // Optional: Draw waypoints in editor
    void OnDrawGizmos()
    {
        if (_waypoints == null || _waypoints.Length == 0) return;

        Gizmos.color = Color.green;
        for (int i = 0; i < _waypoints.Length; i++)
        {
            if (_waypoints[i] != null)
                Gizmos.DrawSphere(_waypoints[i].position, 0.2f);

            if (i < _waypoints.Length - 1 && _waypoints[i] != null && _waypoints[i + 1] != null)
                Gizmos.DrawLine(_waypoints[i].position, _waypoints[i + 1].position);
        }
    }

}
