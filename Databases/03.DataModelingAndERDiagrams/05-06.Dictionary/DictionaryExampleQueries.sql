------------------TASK 05 examples----------------
--Synonym example
Select w.Name as Word, w2.Name as [Synonym]
FROM SynonymConnections sc JOIN Words w
	ON sc.WordID = w.WordID JOIN Words w2
	ON sc.SynonymWordID = w2.WordID

--Translation example
SELECT w.Name as Word, w2.Name as Translation
FROM TranslationConnections tc JOIN Words w
	ON tc.WordID = w.WordID JOIN Words w2
	ON tc.TranslationWordID = w2.WordID

--Explanation example
SELECT w.Name as Word, e.Name as Explanation
FROM WordsAndExplanations we JOIN Words w
	ON we.WordID = w.WordID JOIN Explanations e
	ON we.ExplanationID = e.ExplanationID

------------------TASK 06 examples----------------

--Antonym example
Select w.Name as Word, w2.Name as Antonym
FROM AntonymConnections ac JOIN Words w
	ON ac.WordID = w.WordID JOIN Words w2
	ON Ac.AntonymWordID = w2.WordID

--Part-of-speech example
SELECT w.Name as Word, ps.Name as [Part of speech]
FROM Words w, PartsOfSpeech ps
WHERE w.PartOfSpeechID = ps.PartOfSPeechID

--Hypernym example
SELECT w.Name as Word, w2.Name as Hypernym
FROM HypernymConnections hc JOIN Words w
	ON hc.WordID = w.WordID JOIN Words w2
	ON hc.HypernymWordID = w2.WordID