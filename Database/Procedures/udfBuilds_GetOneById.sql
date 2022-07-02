DROP FUNCTION builds_getonebyid;
create or replace FUNCTION Builds_GetOneById(_build_id_to_find int)
    returns TABLE (
    build_id int,
    title text,
    archived bool
                  )
language plpgsql
as $$
begin
    RETURN QUERY
    SELECT builds.build_id, builds.title, builds.archived
    FROM builds
    WHERE builds.build_id = _build_id_to_find;
end;$$;